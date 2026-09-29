// Week 1 test: the power example from lecture 1 (slides 19 and 23).
// Run the whole file: click the "FSI: Send File" button at the top right of the editor.
// Run only some lines: select them and press Option+Enter.

let rec power(x,n) =
  match (x,n) with
  | (_,0) -> 1.0
  | (x,n) -> x * power(x,n-1)

printfn "power(4.0, 2) = %f" (power(4.0, 2))
