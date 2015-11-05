// 1,1
(* Programming language concepts for software developers, 2010-08-28 *)

(* Evaluating simple expressions with variables *)

module Intro2

(* Association lists map object language variables to their values *)

let env = [("a", 3); ("c", 78); ("baf", 666); ("b", 111)]

let emptyenv = [] (* the empty environment *)

let rec lookup env x =
    match env with 
    | []        -> failwith (x + " not found")
    | (y, v)::r -> if x=y then v else lookup r x

let cvalue = lookup env "c"


(* Object language expressions with variables *)

type expr = 
  | CstI of int
  | Var of string
  | Prim of string * expr * expr
  | If of expr * expr * expr (*(iv)*)

let e1 = CstI 17

let e2 = Prim("+", CstI 3, Var "a")

let e3 = Prim("+", Prim("*", Var "b", CstI 9), Var "a")

(*(ii)*)
let e4 = Prim("max", CstI 12, Var "c")

let e5 = Prim("min", e1, e4)

let e6 = Prim("==", e5, e5)

(* Evaluation within an environment *)
(*iii*)
let rec eval e (env : (string * int) list) : int =
    match e with
    | CstI i            -> i
    | Var x             -> lookup env x 
    | If(con, e1, e2)   -> if eval con env <> 0 then eval e1 env else eval e2 env (*(v)*)
    | Prim(ope, e1, e2) -> 
        let i1 = eval e1 env
        let i2 = eval e2 env
        match ope with
        | "+"   -> i1 + i2
        | "*"   -> i1 * i2
        | "-"   -> i1 - i2
        | "max" -> if i1 > i2 then i1 else i2 (*(i)*)
        | "min" -> if i1 < i2 then i1 else i2 (*(i)*)
        | "=="  -> if i1 = i2 then 1 else 0 (*(i)*)
        | _     -> failwith "unknown primitive"

let e1v  = eval e1 env
let e2v1 = eval e2 env
let e2v2 = eval e2 [("a", 314)]
let e3v  = eval e3 env
let e4v = eval e4 env
let e5v = eval e5 env
let e6v = eval e6 env

// 1,2
(*i*)
type aexpr =
    | CstI  of int
    | Var   of string
    | Add   of aexpr * aexpr
    | Sub   of aexpr * aexpr
    | Mul   of aexpr * aexpr

(*ii*)
let aexpr1 = Sub(Var "v", Add(Var "w", Var "z"))
let aexpr2 = Mul(CstI 2, Sub(Var "v", Add(Var "w", Var "z")))
let aexpr3 = Add(Var "x", Add(Var "y", Add(Var "z", Var "v")))

(*iii*)
let rec fmt (ae:aexpr) : string = 
    match ae with
    | CstI(i)       -> i.ToString()
    | Var(v)        -> v
    | Add(e1, e2)   -> "(" + fmt e1 + "+" + fmt e2 + ")"
    | Sub(e1, e2)   -> "(" + fmt e1 + "-" + fmt e2 + ")"
    | Mul(e1, e2)   -> "(" + fmt e1 + "*" + fmt e2 + ")"

(*iv*)
let rec simplify (ae:aexpr) : aexpr = 
    match ae with
    | Add(CstI(0), e2)          -> simplify e2
    | Add(e1, CstI(0))          -> simplify e1
    | Sub(e1, CstI(0))          -> simplify e1
    | Mul(e1, CstI(1))          -> simplify e1
    | Mul(CstI(1), e2)          -> simplify e2
    | Mul(e1, CstI(0))          -> CstI 0
    | Mul(CstI(0), e2)          -> CstI 0
    | Sub(e1, e2) when e1 = e2  -> CstI 0
    | Add(e1, e2)               -> simplify (Add(simplify e1, simplify e2))
    | Sub(e1, e2)               -> simplify (Sub(simplify e1, simplify e2))
    | Mul(e1, e2)               -> simplify (Mul(simplify e1, simplify e2))
    | ae                        -> ae

let aexpr4 = Add(CstI 0, Sub(CstI 4, CstI 0))
simplify aexpr4
let aexpr5 = Mul(Add(CstI 1, CstI 0), Add(Var "x", CstI 0))
simplify aexpr5


(*v*)
let rec diff (ae:aexpr) : aexpr =
    match ae with
    | CstI(i)       -> CstI 0
    | Var(v)        -> CstI 1 (*"...With respect to a single variable."*)
    | Add(e1, e2)   -> Add(diff e1, diff e2)
    | Sub(e1, e2)   -> Sub(diff e1, diff e2)
    | Mul(e1, e2)   -> Add(Mul(diff e1, e2), Mul(e1, diff e2))
    

let aexpr6 = Mul(Var "x", CstI 3)
simplify <| diff aexpr6

//2,1
type expr = 
  | CstI of int
  | Var of string
  | Let of (string * expr) list * expr
  | Prim of string * expr * expr;;
(* Some closed expressions: *)
(* ---------------------------------------------------------------------- *)
(* Evaluation of expressions with variables and bindings *)
let rec lookup env x =
    match env with 
    | []        -> failwith (x + " not found")
    | (y, v)::r -> if x=y then v else lookup r x;;
let rec eval e (env : (string * int) list) : int =
    match e with
    | CstI i            -> i
    | Var x             -> lookup env x 
    | Let([], ebody) -> eval ebody env
    | Let((x,ex)::xs, ebody) ->
        let xval = eval ex env
        let env1 = (x, xval) :: env
        if xs = [] then eval ebody env1 else eval (Let(xs, ebody)) env1
    | Prim("+", e1, e2) -> eval e1 env + eval e2 env
    | Prim("*", e1, e2) -> eval e1 env * eval e2 env
    | Prim("-", e1, e2) -> eval e1 env - eval e2 env
    | Prim _            -> failwith "unknown primitive";;
let run e = eval e [];;
(* ---------------------------------------------------------------------- *)

//2,2
(* Closedness *)
// let mem x vs = List.exists (fun y -> x=y) vs;;
let rec mem x vs = 
    match vs with
    | []      -> false
    | v :: vr -> x=v || mem x vr;;
(* union(xs, ys) is the set of all elements in xs or ys, without duplicates *)
let rec union (xs, ys) = 
    match xs with 
    | []    -> ys
    | x::xr -> if mem x ys then union(xr, ys)
               else x :: union(xr, ys);;
(* minus xs ys  is the set of all elements in xs but not in ys *)
let rec minus (xs, ys) = 
    match xs with 
    | []    -> []
    | x::xr -> if mem x ys then minus(xr, ys)
               else x :: minus (xr, ys);;
let rec freevars e : string list =
    match e with
    | CstI i -> []
    | Var x  -> [x]
    | Let([], ebody) -> freevars ebody
    | Let((x, ex)::xs, ebody) ->
        if xs = [] then union (freevars ex, minus (freevars ebody, [x]))
        else minus (freevars ex, [x])
    | Prim(ope, e1, e2) -> union (freevars e1, freevars e2)
(* ---------------------------------------------------------------------- *)

//2,3
(* Compilation to target expressions with numerical indexes instead of
   symbolic variable names.  *)
type texpr =                            (* target expressions *)
  | TCstI of int
  | TVar of int                         (* index into runtime environment *)
  | TLet of texpr * texpr               (* erhs and ebody                 *)
  | TPrim of string * texpr * texpr;;
(* Map variable name to variable index at compile-time *)
let rec getindex vs x = 
    match vs with 
    | []    -> failwith "Variable not found"
    | y::yr -> if x=y then 0 else 1 + getindex yr x;;
let rec tcomp (e : expr) (cenv : string list) : texpr =
    match e with
    | CstI i -> TCstI i
    | Var x  -> TVar (getindex cenv x)
    | Let((x,ex)::xs, ebody) ->
        let cenv1 = x :: cenv     
        if xs = [] then TLet(tcomp ex cenv, tcomp ebody cenv1) else TLet(tcomp ex cenv, tcomp (Let(xs, ebody)) cenv1)
    | Prim(ope, e1, e2) -> TPrim(ope, tcomp e1 cenv, tcomp e2 cenv);;
(* Evaluation of target expressions with variable indexes.  The
   run-time environment renv is a list of variable values (ints).  *)
let rec teval (e : texpr) (renv : int list) : int =
    match e with
    | TCstI i -> i
    | TVar n  -> List.nth renv n
    | TLet(erhs, ebody) -> 
      let xval = teval erhs renv
      let renv1 = xval :: renv 
      teval ebody renv1 
    | TPrim("+", e1, e2) -> teval e1 renv + teval e2 renv
    | TPrim("*", e1, e2) -> teval e1 renv * teval e2 renv
    | TPrim("-", e1, e2) -> teval e1 renv - teval e2 renv
    | TPrim _            -> failwith "unknown primitive";;
let i = Let([], Let(["x1", Prim("+", Var "x1", CstI 4)], Prim("+", Var "x1", CstI 3))) // []
let fault = Let([("x1", Prim("+", Var "x1", CstI 7))], Prim("+", Var "x1", CstI 8)) // [x1]
let l = Let ([("x1", Prim("+", CstI 5, CstI 7)); ("x2", Prim("*", Var "x1", CstI 2))], Prim("+", Var "x1", Var "x2"))