#r @"bin\Debug\FsLexYacc.Runtime.dll"

#load "Absyn.fs"
#load "Expr.fs"
#load "ExprPar.fs"
#load "ExprLex.fs"
#load "Parse.fs"

open Parse

let ss = [
    "2+3*4"
]

List.map fromString ss

ignore <| System.Console.ReadLine ()