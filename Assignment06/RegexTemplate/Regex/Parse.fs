module Parse

open System
open System.IO
open System.Text
open Microsoft.FSharp.Text.Lexing
open Absyn

let fromString (str : string) : re =
    let lexbuf = LexBuffer<char>.FromString(str)
    try 
      RePar.Main ReLex.Token lexbuf
    with 
      | exn -> let pos = lexbuf.EndPos 
               failwithf "%s near line %d, column %d\n" 
                  (exn.Message) (pos.Line+1) pos.Column