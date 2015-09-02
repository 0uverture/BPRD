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