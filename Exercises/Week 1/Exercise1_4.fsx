// Exercise 1.4: Define a function f where f(n) = 1 + 2 + 3 + 4 + ... + n

let rec f n =  // declares recursive function named f accepting a single parameter n. The rec keyword enables the function to practically call itself
    match n with // initiates patern matching on the vlue of n to control execution flow.
    | 0 -> 0 // defines the base condition. If n equals to 0, the function evaluates to 0, halting further recursion on this branch.
    | n -> n + f (n-1) // defines the recursive step and matches any remaining value, adds n to the result of f evaluated with n - 1, and returns the sum. 


// additional exercise x.x: Define a function f where f(n) = 2 + 4 + 6 + ... + n

let rec y n =  // declares the recursive function f taking parameter n.
    match n with // initiates pattern matching on n.
    | 0 -> 0 // Base condition halts recursion when n reaches 0.
    | n -> n + f (n - 2) // recursive step. adds the current even number n to the result of f evaluated with the next lowest even number ( n- 2 ).

