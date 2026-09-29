02157 Functional Programming, Week 3
02157 Functional Programming
Week 3:
Structuring and Typing
Sebastian Mödersheim
Based on slides by Michael Reichhardt Hansen
September 18, 2026
1 of 39
Outline
1 Review
2 On functions as first-class citizens
3 Type Inference
02157 Functional Programming, Week 3 2 of 39 Exercises
• HR 1.5: the Fibonacci numbers
F0 = 0
F1 = 1
Fn = Fn−1 + Fn−2 for n > 1
• HR 2.2: pow(s, n) = s · s · . . . · s
| {z }
n
for string s and int n.
• HR 4.7: multiplicity x xs – compute the number of times x occurs in xs.
• Polynome exercise from slide ?? (≈ HR 4.22).
• Merge sort: idea explained in class on blackbord
Define helper functions (they are all in the List library, but easy to write
yourself):
⋆ length: ’a list->int length of a list
e.g. length [1;2;3] = 3
⋆ split: int->’a list->(’a list,’a list) split a list into two after a given
number of elements
e.g. split 2 [1;2;3;4;5] = ([1;2],[3;4;5])
⋆ merge: (’a list,’a list) -> ’a list merge a pair of sorted lists into one
sorted list.
Put it together into mergesort.
02157 Functional Programming, Week 3 3 of 39 Outline
1 Review
2 On functions as first-class citizens
3 Type Inference
02157 Functional Programming, Week 3 4 of 39 Functions as ”first-class citizens”
• functions can be passed as arguments to functions
• functions can be returned as values of functions
like any other kind of value.
There is nothing special about functions in functional languages
A function that takes a function as argument or produces a function as result is also
called a higher-order function.
Higher-order functions are useful
• succinct code
• highly parameterized programs
• Program libraries typically contain many such functions
02157 Functional Programming, Week 3 5 of 39 Functions as ”first-class citizens”
• functions can be passed as arguments to functions
• functions can be returned as values of functions
like any other kind of value.
There is nothing special about functions in functional languages
A function that takes a function as argument or produces a function as result is also
called a higher-order function.
Higher-order functions are useful
• succinct code
• highly parameterized programs
• Program libraries typically contain many such functions
02157 Functional Programming, Week 3 5 of 39 Functions as ”first-class citizens”
• functions can be passed as arguments to functions
• functions can be returned as values of functions
like any other kind of value.
There is nothing special about functions in functional languages
A function that takes a function as argument or produces a function as result is also
called a higher-order function.
Higher-order functions are useful
• succinct code
• highly parameterized programs
• Program libraries typically contain many such functions
02157 Functional Programming, Week 3 5 of 39 Functions as ”first-class citizens”
• functions can be passed as arguments to functions
• functions can be returned as values of functions
like any other kind of value.
There is nothing special about functions in functional languages
A function that takes a function as argument or produces a function as result is also
called a higher-order function.
Higher-order functions are useful
• succinct code
• highly parameterized programs
• Program libraries typically contain many such functions
02157 Functional Programming, Week 3 5 of 39 Functions as ”first-class citizens”
• functions can be passed as arguments to functions
• functions can be returned as values of functions
like any other kind of value.
There is nothing special about functions in functional languages
A function that takes a function as argument or produces a function as result is also
called a higher-order function.
Higher-order functions are useful
• succinct code
• highly parameterized programs
• Program libraries typically contain many such functions
02157 Functional Programming, Week 3 5 of 39 An example
Suppose that we have a cube with side length s, containing a liquid with density ρ.
The weight of the liquid is then given by ρ · s
3
:
let weight ro s = ro * s ** 3.0;;
val weight : float -> float -> float
We can make partial evaluations to define functions for computing the weight of a
cube of either water or methanol:
let waterWeight = weight 1000.0;;
val waterWeight : (float -> float)
waterWeight 2.0;;
val it : float = 8000.0
let methanolWeight = weight 786.5 ;;
val methanolWeight : (float -> float)
methanolWeight 2.0;;
val it : float = 6292.0
The formula ρ · s
3
is represented just once in the program
02157 Functional Programming, Week 3 6 of 39 An example
Suppose that we have a cube with side length s, containing a liquid with density ρ.
The weight of the liquid is then given by ρ · s
3
:
let weight ro s = ro * s ** 3.0;;
val weight : float -> float -> float
We can make partial evaluations to define functions for computing the weight of a
cube of either water or methanol:
let waterWeight = weight 1000.0;;
val waterWeight : (float -> float)
waterWeight 2.0;;
val it : float = 8000.0
let methanolWeight = weight 786.5 ;;
val methanolWeight : (float -> float)
methanolWeight 2.0;;
val it : float = 6292.0
The formula ρ · s
3
is represented just once in the program
02157 Functional Programming, Week 3 6 of 39 An example
Suppose that we have a cube with side length s, containing a liquid with density ρ.
The weight of the liquid is then given by ρ · s
3
:
let weight ro s = ro * s ** 3.0;;
val weight : float -> float -> float
We can make partial evaluations to define functions for computing the weight of a
cube of either water or methanol:
let waterWeight = weight 1000.0;;
val waterWeight : (float -> float)
waterWeight 2.0;;
val it : float = 8000.0
let methanolWeight = weight 786.5 ;;
val methanolWeight : (float -> float)
methanolWeight 2.0;;
val it : float = 6292.0
The formula ρ · s
3
is represented just once in the program
02157 Functional Programming, Week 3 6 of 39 An example
Suppose that we have a cube with side length s, containing a liquid with density ρ.
The weight of the liquid is then given by ρ · s
3
:
let weight ro s = ro * s ** 3.0;;
val weight : float -> float -> float
We can make partial evaluations to define functions for computing the weight of a
cube of either water or methanol:
let waterWeight = weight 1000.0;;
val waterWeight : (float -> float)
waterWeight 2.0;;
val it : float = 8000.0
let methanolWeight = weight 786.5 ;;
val methanolWeight : (float -> float)
methanolWeight 2.0;;
val it : float = 6292.0
The formula ρ · s
3
is represented just once in the program
02157 Functional Programming, Week 3 6 of 39 Currying and Uncurrying
The process of turning a function on pairs (tuples) into a higher-order function is
called currying. The opposite process is called uncurrying.
Consider declarations:
let wC ro s = ro * s ** 3.0;;
val wC : float -> float -> float
let wUC(ro, s) = ro * s ** 3.0;;
val wUC : ro:float * s:float -> float
• wC is the curried version of wUC
• wUC is the uncurried version of wC
Have a look at exercise HR 2.13:
• declare functions for curring and uncurring.
curry: (’a * ’b -> ’c) -> ’a -> ’b -> ’c
uncurry: (’a -> ’b -> ’c) -> ’a * ’b -> ’c
02157 Functional Programming, Week 3 7 of 39 Currying and Uncurrying
The process of turning a function on pairs (tuples) into a higher-order function is
called currying. The opposite process is called uncurrying.
Consider declarations:
let wC ro s = ro * s ** 3.0;;
val wC : float -> float -> float
let wUC(ro, s) = ro * s ** 3.0;;
val wUC : ro:float * s:float -> float
• wC is the curried version of wUC
• wUC is the uncurried version of wC
Have a look at exercise HR 2.13:
• declare functions for curring and uncurring.
curry: (’a * ’b -> ’c) -> ’a -> ’b -> ’c
uncurry: (’a -> ’b -> ’c) -> ’a * ’b -> ’c
02157 Functional Programming, Week 3 7 of 39 Currying and Uncurrying
The process of turning a function on pairs (tuples) into a higher-order function is
called currying. The opposite process is called uncurrying.
Consider declarations:
let wC ro s = ro * s ** 3.0;;
val wC : float -> float -> float
let wUC(ro, s) = ro * s ** 3.0;;
val wUC : ro:float * s:float -> float
• wC is the curried version of wUC
• wUC is the uncurried version of wC
Have a look at exercise HR 2.13:
• declare functions for curring and uncurring.
curry: (’a * ’b -> ’c) -> ’a -> ’b -> ’c
uncurry: (’a -> ’b -> ’c) -> ’a * ’b -> ’c
02157 Functional Programming, Week 3 7 of 39 A well-known example: function composition
Function composition: (f ◦ g)(x) = f (g(x))
For example, if f (y) = y + 3 and g(x) = x
2
, then (f ◦ g)(z) = z
2 + 3.
The infix operator << in F# denotes function composition:
let f y = y+3;;
let g x = x*x;;
let h = f << g;; // h = (f o g)
val h : int -> int
h 4;; // h(4) = (f o g)(4)
val it : int = 19
• An infix operator appears between the arguments
02157 Functional Programming, Week 3 8 of 39 A well-known example: function composition
Function composition: (f ◦ g)(x) = f (g(x))
For example, if f (y) = y + 3 and g(x) = x
2
, then (f ◦ g)(z) = z
2 + 3.
The infix operator << in F# denotes function composition:
let f y = y+3;;
let g x = x*x;;
let h = f << g;; // h = (f o g)
val h : int -> int
h 4;; // h(4) = (f o g)(4)
val it : int = 19
• An infix operator appears between the arguments
02157 Functional Programming, Week 3 8 of 39 Infix functions
The prefix version (⊕) of an infix operator ⊕ is a curried function, that is,
higher-order function where argument are supplied one by one
For example:
(<<);;
val it : ((’a -> ’b) -> (’c -> ’a) -> ’c -> ’b)
• The argument is a function ’a -> ’b
• The value is a function (’c -> ’a) -> ’c -> ’b
Declaration << is a built-in function
let (<<) f g x = f(g x);;
Infix operators are written as strings of special characters including
! % & * + - / < = > ? @ ^ \ ~
Consult F# specification for complete rules.
02157 Functional Programming, Week 3 9 of 39 Infix functions
The prefix version (⊕) of an infix operator ⊕ is a curried function, that is,
higher-order function where argument are supplied one by one
For example:
(<<);;
val it : ((’a -> ’b) -> (’c -> ’a) -> ’c -> ’b)
• The argument is a function ’a -> ’b
• The value is a function (’c -> ’a) -> ’c -> ’b
Declaration << is a built-in function
let (<<) f g x = f(g x);;
Infix operators are written as strings of special characters including
! % & * + - / < = > ? @ ^ \ ~
Consult F# specification for complete rules.
02157 Functional Programming, Week 3 9 of 39 Infix functions
The prefix version (⊕) of an infix operator ⊕ is a curried function, that is,
higher-order function where argument are supplied one by one
For example:
(<<);;
val it : ((’a -> ’b) -> (’c -> ’a) -> ’c -> ’b)
• The argument is a function ’a -> ’b
• The value is a function (’c -> ’a) -> ’c -> ’b
Declaration << is a built-in function
let (<<) f g x = f(g x);;
Infix operators are written as strings of special characters including
! % & * + - / < = > ? @ ^ \ ~
Consult F# specification for complete rules.
02157 Functional Programming, Week 3 9 of 39 Infix functions
The prefix version (⊕) of an infix operator ⊕ is a curried function, that is,
higher-order function where argument are supplied one by one
For example:
(<<);;
val it : ((’a -> ’b) -> (’c -> ’a) -> ’c -> ’b)
• The argument is a function ’a -> ’b
• The value is a function (’c -> ’a) -> ’c -> ’b
Declaration << is a built-in function
let (<<) f g x = f(g x);;
Infix operators are written as strings of special characters including
! % & * + - / < = > ? @ ^ \ ~
Consult F# specification for complete rules.
02157 Functional Programming, Week 3 9 of 39 Infix functions
The prefix version (⊕) of an infix operator ⊕ is a curried function, that is,
higher-order function where argument are supplied one by one
For example:
(<<);;
val it : ((’a -> ’b) -> (’c -> ’a) -> ’c -> ’b)
• The argument is a function ’a -> ’b
• The value is a function (’c -> ’a) -> ’c -> ’b
Declaration << is a built-in function
let (<<) f g x = f(g x);;
Infix operators are written as strings of special characters including
! % & * + - / < = > ? @ ^ \ ~
Consult F# specification for complete rules.
02157 Functional Programming, Week 3 9 of 39 The built-in infix function @
List.append is a higher-order function from the List library:
• List.append [x0; . . . ; xn−1] [y0; . . . ; xm−1] =
[x0; . . . ; xn−1; y0; . . . ; xm−1]
There is a convenient infix notation for List.append xs ys in F#:
xs @ ys
02157 Functional Programming, Week 3 10 of 39 The built-in infix function @
List.append is a higher-order function from the List library:
• List.append [x0; . . . ; xn−1] [y0; . . . ; xm−1] =
[x0; . . . ; xn−1; y0; . . . ; xm−1]
There is a convenient infix notation for List.append xs ys in F#:
xs @ ys
02157 Functional Programming, Week 3 10 of 39 Function expressions
Function Expressions
Let x be a variable of type τ0 and e be an expression of type τ . Then also
fun x -> e
is an expression that defines a function that takes an x and returns e. Thus, the
resulting expression is of type τ0 → τ .
• We will later discuss lambda calculus, the logical basis for functional
programming.
• The fun x -> e in F# corresponds to λx.e in the lambda calculus and reads:
“the function of x given by e”.
02157 Functional Programming, Week 3 11 of 39 Anonymous function with pattern matching
We often would like to have pattern matching on variables, i.e.,
fun x ->
match x with
| p1 -> e1
...
| pn -> en
F# offers the following syntactic sugar for that:
function
| p1 -> e1
...
| pn -> en
02157 Functional Programming, Week 3 12 of 39 Anonymous function with pattern matching
We often would like to have pattern matching on variables, i.e.,
fun x ->
match x with
| p1 -> e1
...
| pn -> en
F# offers the following syntactic sugar for that:
function
| p1 -> e1
...
| pn -> en
02157 Functional Programming, Week 3 12 of 39 Example
An anonymous function computing the number of days in a month:
function
| 2 -> 28 // February
| 4 -> 30 // April
| 6 -> 30 // June
| 9 -> 30 // September
| 11 -> 30 // November
| _ -> 31;; // All other months
val it : int -> int = <fun:clo@17-2>
it 2;;
val it : int = 28
02157 Functional Programming, Week 3 13 of 39 Example
An anonymous function computing the number of days in a month:
function
| 2 -> 28 // February
| 4 -> 30 // April
| 6 -> 30 // June
| 9 -> 30 // September
| 11 -> 30 // November
| _ -> 31;; // All other months
val it : int -> int = <fun:clo@17-2>
it 2;;
val it : int = 28
02157 Functional Programming, Week 3 13 of 39 Anonymous functions: Example 3
Function expressions with general patterns, e.g.
function
| 2 -> 28 // February
|4|6|9|11 -> 30 // April, June, September, November
| _ -> 31 // All other months
;;
Exploits an or pattern in the second clause
02157 Functional Programming, Week 3 14 of 39 Anonymous functions: Example 3
Function expressions with general patterns, e.g.
function
| 2 -> 28 // February
|4|6|9|11 -> 30 // April, June, September, November
| _ -> 31 // All other months
;;
Exploits an or pattern in the second clause
02157 Functional Programming, Week 3 14 of 39 Simple functions expressions with currying
The expression
fun x y · · · z → e
has the same meaning as
fun x → (fun y → (· · · (fun z → e)· · ·))
It denotes a function with type
tx → (ty → (· · ·(tz → te )· · ·)) where x : tx , y : ty , z : tz and e : te
For example: The function below takes an integer as argument and returns a
function of type int -> int as value:
fun x y -> x + x*y;;
val it : int -> int -> int = <fun:clo@2-1>
let f = it 2;;
val f : ( int -> int)
f 3;;
val it : int = 8
02157 Functional Programming, Week 3 15 of 39 Simple functions expressions with currying
The expression
fun x y · · · z → e
has the same meaning as
fun x → (fun y → (· · · (fun z → e)· · ·))
It denotes a function with type
tx → (ty → (· · ·(tz → te )· · ·)) where x : tx , y : ty , z : tz and e : te
For example: The function below takes an integer as argument and returns a
function of type int -> int as value:
fun x y -> x + x*y;;
val it : int -> int -> int = <fun:clo@2-1>
let f = it 2;;
val f : ( int -> int)
f 3;;
val it : int = 8
02157 Functional Programming, Week 3 15 of 39 Simple functions expressions with currying
The expression
fun x y · · · z → e
has the same meaning as
fun x → (fun y → (· · · (fun z → e)· · ·))
It denotes a function with type
tx → (ty → (· · ·(tz → te )· · ·)) where x : tx , y : ty , z : tz and e : te
For example: The function below takes an integer as argument and returns a
function of type int -> int as value:
fun x y -> x + x*y;;
val it : int -> int -> int = <fun:clo@2-1>
let f = it 2;;
val f : ( int -> int)
f 3;;
val it : int = 8
02157 Functional Programming, Week 3 15 of 39 Simple functions expressions with currying
The expression
fun x y · · · z → e
has the same meaning as
fun x → (fun y → (· · · (fun z → e)· · ·))
It denotes a function with type
tx → (ty → (· · ·(tz → te )· · ·)) where x : tx , y : ty , z : tz and e : te
For example: The function below takes an integer as argument and returns a
function of type int -> int as value:
fun x y -> x + x*y;;
val it : int -> int -> int = <fun:clo@2-1>
let f = it 2;;
val f : ( int -> int)
f 3;;
val it : int = 8
02157 Functional Programming, Week 3 15 of 39 Simple functions expressions with currying
The expression
fun x y · · · z → e
has the same meaning as
fun x → (fun y → (· · · (fun z → e)· · ·))
It denotes a function with type
tx → (ty → (· · ·(tz → te )· · ·)) where x : tx , y : ty , z : tz and e : te
For example: The function below takes an integer as argument and returns a
function of type int -> int as value:
fun x y -> x + x*y;;
val it : int -> int -> int = <fun:clo@2-1>
let f = it 2;;
val f : ( int -> int)
f 3;;
val it : int = 8
02157 Functional Programming, Week 3 15 of 39 Outline
1 Review
2 On functions as first-class citizens
3 Type Inference
02157 Functional Programming, Week 3 16 of 39 Types and type checking
Purposes:
• Modelling, readability: types are used to indicate the intention behind a
program
• Safety, efficiency: ”Well-typed programs do not go wrong”
Robin Milner
⋆ Actually, a well-typed program can still have bugs, but a good type system will
rule out a lot of buggy programs.
⇒ It is a very useful restriction to require well-typed programs
⋆ Some ill-typed programs may still be fine, but typically it is not difficult to
re-write them into well-typed ones.
⇒ Restriction to well-typed is in practice not burden.
• Catch errors at compile time
⋆ Checks of types are not needed at runtime
A type checker is an algorithm used at an early phase in the compiler to reject
programs containing type errors.
Type inference is an algorithm to automatically calculate types of expressions
without use of explicit type annotations.
02157 Functional Programming, Week 3 17 of 39 Types and type checking
Purposes:
• Modelling, readability: types are used to indicate the intention behind a
program
• Safety, efficiency: ”Well-typed programs do not go wrong”
Robin Milner
⋆ Actually, a well-typed program can still have bugs, but a good type system will
rule out a lot of buggy programs.
⇒ It is a very useful restriction to require well-typed programs
⋆ Some ill-typed programs may still be fine, but typically it is not difficult to
re-write them into well-typed ones.
⇒ Restriction to well-typed is in practice not burden.
• Catch errors at compile time
⋆ Checks of types are not needed at runtime
A type checker is an algorithm used at an early phase in the compiler to reject
programs containing type errors.
Type inference is an algorithm to automatically calculate types of expressions
without use of explicit type annotations.
02157 Functional Programming, Week 3 17 of 39 Types and type checking
Purposes:
• Modelling, readability: types are used to indicate the intention behind a
program
• Safety, efficiency: ”Well-typed programs do not go wrong”
Robin Milner
⋆ Actually, a well-typed program can still have bugs, but a good type system will
rule out a lot of buggy programs.
⇒ It is a very useful restriction to require well-typed programs
⋆ Some ill-typed programs may still be fine, but typically it is not difficult to
re-write them into well-typed ones.
⇒ Restriction to well-typed is in practice not burden.
• Catch errors at compile time
⋆ Checks of types are not needed at runtime
A type checker is an algorithm used at an early phase in the compiler to reject
programs containing type errors.
Type inference is an algorithm to automatically calculate types of expressions
without use of explicit type annotations.
02157 Functional Programming, Week 3 17 of 39 Types and type checking
Purposes:
• Modelling, readability: types are used to indicate the intention behind a
program
• Safety, efficiency: ”Well-typed programs do not go wrong”
Robin Milner
⋆ Actually, a well-typed program can still have bugs, but a good type system will
rule out a lot of buggy programs.
⇒ It is a very useful restriction to require well-typed programs
⋆ Some ill-typed programs may still be fine, but typically it is not difficult to
re-write them into well-typed ones.
⇒ Restriction to well-typed is in practice not burden.
• Catch errors at compile time
⋆ Checks of types are not needed at runtime
A type checker is an algorithm used at an early phase in the compiler to reject
programs containing type errors.
Type inference is an algorithm to automatically calculate types of expressions
without use of explicit type annotations.
02157 Functional Programming, Week 3 17 of 39 Types and type checking
Purposes:
• Modelling, readability: types are used to indicate the intention behind a
program
• Safety, efficiency: ”Well-typed programs do not go wrong”
Robin Milner
⋆ Actually, a well-typed program can still have bugs, but a good type system will
rule out a lot of buggy programs.
⇒ It is a very useful restriction to require well-typed programs
⋆ Some ill-typed programs may still be fine, but typically it is not difficult to
re-write them into well-typed ones.
⇒ Restriction to well-typed is in practice not burden.
• Catch errors at compile time
⋆ Checks of types are not needed at runtime
A type checker is an algorithm used at an early phase in the compiler to reject
programs containing type errors.
Type inference is an algorithm to automatically calculate types of expressions
without use of explicit type annotations.
02157 Functional Programming, Week 3 17 of 39 Types and type checking
Purposes:
• Modelling, readability: types are used to indicate the intention behind a
program
• Safety, efficiency: ”Well-typed programs do not go wrong”
Robin Milner
⋆ Actually, a well-typed program can still have bugs, but a good type system will
rule out a lot of buggy programs.
⇒ It is a very useful restriction to require well-typed programs
⋆ Some ill-typed programs may still be fine, but typically it is not difficult to
re-write them into well-typed ones.
⇒ Restriction to well-typed is in practice not burden.
• Catch errors at compile time
⋆ Checks of types are not needed at runtime
A type checker is an algorithm used at an early phase in the compiler to reject
programs containing type errors.
Type inference is an algorithm to automatically calculate types of expressions
without use of explicit type annotations.
02157 Functional Programming, Week 3 17 of 39 Type inference
The type system of F# allows for polymorphic types, that is, types with many
forms. Polymorphic types are expressed using type variables ’a, ’b, ’c, ...
Textbooks (and Sebastian) often write greek letters for type variables like α, β, γ, . . ..
The most general type or principal type is inferred by the system.
Examples:
let id x = x
val id : ’a -> ’a
let pair x y = (x,y)
val pair : ’a -> ’b -> ’a * ’b
The inferred types are most general in the sense that all other types for id and pair
are instances of the inferred types.
By the type of a function, we (usually) mean the most general type
Remark: identity function id is a built-in function
02157 Functional Programming, Week 3 18 of 39 Type inference
The type system of F# allows for polymorphic types, that is, types with many
forms. Polymorphic types are expressed using type variables ’a, ’b, ’c, ...
Textbooks (and Sebastian) often write greek letters for type variables like α, β, γ, . . ..
The most general type or principal type is inferred by the system.
Examples:
let id x = x
val id : ’a -> ’a
let pair x y = (x,y)
val pair : ’a -> ’b -> ’a * ’b
The inferred types are most general in the sense that all other types for id and pair
are instances of the inferred types.
By the type of a function, we (usually) mean the most general type
Remark: identity function id is a built-in function
02157 Functional Programming, Week 3 18 of 39 Type inference
The type system of F# allows for polymorphic types, that is, types with many
forms. Polymorphic types are expressed using type variables ’a, ’b, ’c, ...
Textbooks (and Sebastian) often write greek letters for type variables like α, β, γ, . . ..
The most general type or principal type is inferred by the system.
Examples:
let id x = x
val id : ’a -> ’a
let pair x y = (x,y)
val pair : ’a -> ’b -> ’a * ’b
The inferred types are most general in the sense that all other types for id and pair
are instances of the inferred types.
By the type of a function, we (usually) mean the most general type
Remark: identity function id is a built-in function
02157 Functional Programming, Week 3 18 of 39 Type inference
The type system of F# allows for polymorphic types, that is, types with many
forms. Polymorphic types are expressed using type variables ’a, ’b, ’c, ...
Textbooks (and Sebastian) often write greek letters for type variables like α, β, γ, . . ..
The most general type or principal type is inferred by the system.
Examples:
let id x = x
val id : ’a -> ’a
let pair x y = (x,y)
val pair : ’a -> ’b -> ’a * ’b
The inferred types are most general in the sense that all other types for id and pair
are instances of the inferred types.
By the type of a function, we (usually) mean the most general type
Remark: identity function id is a built-in function
02157 Functional Programming, Week 3 18 of 39 Type inference
The type system of F# allows for polymorphic types, that is, types with many
forms. Polymorphic types are expressed using type variables ’a, ’b, ’c, ...
Textbooks (and Sebastian) often write greek letters for type variables like α, β, γ, . . ..
The most general type or principal type is inferred by the system.
Examples:
let id x = x
val id : ’a -> ’a
let pair x y = (x,y)
val pair : ’a -> ’b -> ’a * ’b
The inferred types are most general in the sense that all other types for id and pair
are instances of the inferred types.
By the type of a function, we (usually) mean the most general type
Remark: identity function id is a built-in function
02157 Functional Programming, Week 3 18 of 39 Polymorphic type inference – informally
Given a declaration, for example,
let rec (@) xs ys =
match xs with
| [] -> ys (* C 1 *)
| x::xtail -> x::(xtail @ ys);; (* C 2 *)
• At the beginning of type inference, we give each identifier a new type variable.
⋆ This is like saying: I do not know the type of xs yet, so it is some type τ1.
xs : τ1 ys : τ2 x : τ3 xtail : τ4
• For the function being defined here, we can say: (@) : τ1 → τ2 → τ5
where τ5 represents whatever will be the type of the match... expression.
• Now we add type constraints:
⋆ The result type τ5 must be the same type as the result ys in case C 1: τ5 = τ2
⋆ τ5 must also be the same type as the result in case C 2: x::(xtail @ ys) : τ5
⋆ For builtin :: we have (::) : α → α list → α list where α can be any type.
▶ We need to instantiate α = τ3 here since x : τ3.
⋆ Thus τ5 = τ3 list and xtail @ ys : τ3 list
⋆ Thus xtail : τ1 because xtail is used as first argument of @.
⋆ For the pattern x::xtail to be type correct, we must thus hold: τ1 = τ3 list
⋆ The pattern matching requires that also the pattern [] and the matched
expression xs have the same type τ3 list – which holds.
⋆ Thus: (@) : τ3 list → τ3 list → τ3 list
• The most general type or principle type of @ is thus (renaming τ3 to α):
(@) : α list → α list → α list
02157 Functional Programming, Week 3 19 of 39 Polymorphic type inference – informally
Given a declaration, for example,
let rec (@) xs ys =
match xs with
| [] -> ys (* C 1 *)
| x::xtail -> x::(xtail @ ys);; (* C 2 *)
• At the beginning of type inference, we give each identifier a new type variable.
⋆ This is like saying: I do not know the type of xs yet, so it is some type τ1.
xs : τ1 ys : τ2 x : τ3 xtail : τ4
• For the function being defined here, we can say: (@) : τ1 → τ2 → τ5
where τ5 represents whatever will be the type of the match... expression.
• Now we add type constraints:
⋆ The result type τ5 must be the same type as the result ys in case C 1: τ5 = τ2
⋆ τ5 must also be the same type as the result in case C 2: x::(xtail @ ys) : τ5
⋆ For builtin :: we have (::) : α → α list → α list where α can be any type.
▶ We need to instantiate α = τ3 here since x : τ3.
⋆ Thus τ5 = τ3 list and xtail @ ys : τ3 list
⋆ Thus xtail : τ1 because xtail is used as first argument of @.
⋆ For the pattern x::xtail to be type correct, we must thus hold: τ1 = τ3 list
⋆ The pattern matching requires that also the pattern [] and the matched
expression xs have the same type τ3 list – which holds.
⋆ Thus: (@) : τ3 list → τ3 list → τ3 list
• The most general type or principle type of @ is thus (renaming τ3 to α):
(@) : α list → α list → α list
02157 Functional Programming, Week 3 19 of 39 Polymorphic type inference – informally
Given a declaration, for example,
let rec (@) xs ys =
match xs with
| [] -> ys (* C 1 *)
| x::xtail -> x::(xtail @ ys);; (* C 2 *)
• At the beginning of type inference, we give each identifier a new type variable.
⋆ This is like saying: I do not know the type of xs yet, so it is some type τ1.
xs : τ1 ys : τ2 x : τ3 xtail : τ4
• For the function being defined here, we can say: (@) : τ1 → τ2 → τ5
where τ5 represents whatever will be the type of the match... expression.
• Now we add type constraints:
⋆ The result type τ5 must be the same type as the result ys in case C 1: τ5 = τ2
⋆ τ5 must also be the same type as the result in case C 2: x::(xtail @ ys) : τ5
⋆ For builtin :: we have (::) : α → α list → α list where α can be any type.
▶ We need to instantiate α = τ3 here since x : τ3.
⋆ Thus τ5 = τ3 list and xtail @ ys : τ3 list
⋆ Thus xtail : τ1 because xtail is used as first argument of @.
⋆ For the pattern x::xtail to be type correct, we must thus hold: τ1 = τ3 list
⋆ The pattern matching requires that also the pattern [] and the matched
expression xs have the same type τ3 list – which holds.
⋆ Thus: (@) : τ3 list → τ3 list → τ3 list
• The most general type or principle type of @ is thus (renaming τ3 to α):
(@) : α list → α list → α list
02157 Functional Programming, Week 3 19 of 39 Polymorphic type inference – informally
Given a declaration, for example,
let rec (@) xs ys =
match xs with
| [] -> ys (* C 1 *)
| x::xtail -> x::(xtail @ ys);; (* C 2 *)
• At the beginning of type inference, we give each identifier a new type variable.
⋆ This is like saying: I do not know the type of xs yet, so it is some type τ1.
xs : τ1 ys : τ2 x : τ3 xtail : τ4
• For the function being defined here, we can say: (@) : τ1 → τ2 → τ5
where τ5 represents whatever will be the type of the match... expression.
• Now we add type constraints:
⋆ The result type τ5 must be the same type as the result ys in case C 1: τ5 = τ2
⋆ τ5 must also be the same type as the result in case C 2: x::(xtail @ ys) : τ5
⋆ For builtin :: we have (::) : α → α list → α list where α can be any type.
▶ We need to instantiate α = τ3 here since x : τ3.
⋆ Thus τ5 = τ3 list and xtail @ ys : τ3 list
⋆ Thus xtail : τ1 because xtail is used as first argument of @.
⋆ For the pattern x::xtail to be type correct, we must thus hold: τ1 = τ3 list
⋆ The pattern matching requires that also the pattern [] and the matched
expression xs have the same type τ3 list – which holds.
⋆ Thus: (@) : τ3 list → τ3 list → τ3 list
• The most general type or principle type of @ is thus (renaming τ3 to α):
(@) : α list → α list → α list
02157 Functional Programming, Week 3 19 of 39 Polymorphic type inference – informally
Given a declaration, for example,
let rec (@) xs ys =
match xs with
| [] -> ys (* C 1 *)
| x::xtail -> x::(xtail @ ys);; (* C 2 *)
• At the beginning of type inference, we give each identifier a new type variable.
⋆ This is like saying: I do not know the type of xs yet, so it is some type τ1.
xs : τ1 ys : τ2 x : τ3 xtail : τ4
• For the function being defined here, we can say: (@) : τ1 → τ2 → τ5
where τ5 represents whatever will be the type of the match... expression.
• Now we add type constraints:
⋆ The result type τ5 must be the same type as the result ys in case C 1: τ5 = τ2
⋆ τ5 must also be the same type as the result in case C 2: x::(xtail @ ys) : τ5
⋆ For builtin :: we have (::) : α → α list → α list where α can be any type.
▶ We need to instantiate α = τ3 here since x : τ3.
⋆ Thus τ5 = τ3 list and xtail @ ys : τ3 list
⋆ Thus xtail : τ1 because xtail is used as first argument of @.
⋆ For the pattern x::xtail to be type correct, we must thus hold: τ1 = τ3 list
⋆ The pattern matching requires that also the pattern [] and the matched
expression xs have the same type τ3 list – which holds.
⋆ Thus: (@) : τ3 list → τ3 list → τ3 list
• The most general type or principle type of @ is thus (renaming τ3 to α):
(@) : α list → α list → α list
02157 Functional Programming, Week 3 19 of 39 Polymorphic type inference – informally
Given a declaration, for example,
let rec (@) xs ys =
match xs with
| [] -> ys (* C 1 *)
| x::xtail -> x::(xtail @ ys);; (* C 2 *)
• At the beginning of type inference, we give each identifier a new type variable.
⋆ This is like saying: I do not know the type of xs yet, so it is some type τ1.
xs : τ1 ys : τ2 x : τ3 xtail : τ4
• For the function being defined here, we can say: (@) : τ1 → τ2 → τ5
where τ5 represents whatever will be the type of the match... expression.
• Now we add type constraints:
⋆ The result type τ5 must be the same type as the result ys in case C 1: τ5 = τ2
⋆ τ5 must also be the same type as the result in case C 2: x::(xtail @ ys) : τ5
⋆ For builtin :: we have (::) : α → α list → α list where α can be any type.
▶ We need to instantiate α = τ3 here since x : τ3.
⋆ Thus τ5 = τ3 list and xtail @ ys : τ3 list
⋆ Thus xtail : τ1 because xtail is used as first argument of @.
⋆ For the pattern x::xtail to be type correct, we must thus hold: τ1 = τ3 list
⋆ The pattern matching requires that also the pattern [] and the matched
expression xs have the same type τ3 list – which holds.
⋆ Thus: (@) : τ3 list → τ3 list → τ3 list
• The most general type or principle type of @ is thus (renaming τ3 to α):
(@) : α list → α list → α list
02157 Functional Programming, Week 3 19 of 39 Polymorphic type inference – informally
Given a declaration, for example,
let rec (@) xs ys =
match xs with
| [] -> ys (* C 1 *)
| x::xtail -> x::(xtail @ ys);; (* C 2 *)
• At the beginning of type inference, we give each identifier a new type variable.
⋆ This is like saying: I do not know the type of xs yet, so it is some type τ1.
xs : τ1 ys : τ2 x : τ3 xtail : τ4
• For the function being defined here, we can say: (@) : τ1 → τ2 → τ5
where τ5 represents whatever will be the type of the match... expression.
• Now we add type constraints:
⋆ The result type τ5 must be the same type as the result ys in case C 1: τ5 = τ2
⋆ τ5 must also be the same type as the result in case C 2: x::(xtail @ ys) : τ5
⋆ For builtin :: we have (::) : α → α list → α list where α can be any type.
▶ We need to instantiate α = τ3 here since x : τ3.
⋆ Thus τ5 = τ3 list and xtail @ ys : τ3 list
⋆ Thus xtail : τ1 because xtail is used as first argument of @.
⋆ For the pattern x::xtail to be type correct, we must thus hold: τ1 = τ3 list
⋆ The pattern matching requires that also the pattern [] and the matched
expression xs have the same type τ3 list – which holds.
⋆ Thus: (@) : τ3 list → τ3 list → τ3 list
• The most general type or principle type of @ is thus (renaming τ3 to α):
(@) : α list → α list → α list
02157 Functional Programming, Week 3 19 of 39 Polymorphic type inference – informally
Given a declaration, for example,
let rec (@) xs ys =
match xs with
| [] -> ys (* C 1 *)
| x::xtail -> x::(xtail @ ys);; (* C 2 *)
• At the beginning of type inference, we give each identifier a new type variable.
⋆ This is like saying: I do not know the type of xs yet, so it is some type τ1.
xs : τ1 ys : τ2 x : τ3 xtail : τ4
• For the function being defined here, we can say: (@) : τ1 → τ2 → τ5
where τ5 represents whatever will be the type of the match... expression.
• Now we add type constraints:
⋆ The result type τ5 must be the same type as the result ys in case C 1: τ5 = τ2
⋆ τ5 must also be the same type as the result in case C 2: x::(xtail @ ys) : τ5
⋆ For builtin :: we have (::) : α → α list → α list where α can be any type.
▶ We need to instantiate α = τ3 here since x : τ3.
⋆ Thus τ5 = τ3 list and xtail @ ys : τ3 list
⋆ Thus xtail : τ1 because xtail is used as first argument of @.
⋆ For the pattern x::xtail to be type correct, we must thus hold: τ1 = τ3 list
⋆ The pattern matching requires that also the pattern [] and the matched
expression xs have the same type τ3 list – which holds.
⋆ Thus: (@) : τ3 list → τ3 list → τ3 list
• The most general type or principle type of @ is thus (renaming τ3 to α):
(@) : α list → α list → α list
02157 Functional Programming, Week 3 19 of 39 Overloaded Operators and Type inference
A squaring function on integers:
Declaration Type
let square x = x * x int -> int Default
A squaring function on floats: square: float -> float
Declaration
let square(x:float) = x * x Type the argument
let square x:float = x * x Type the result
let square x = x * x: float Type expression for the result
let square x = x:float * x Type a variable
You can mix these possibilities
02157 Functional Programming, Week 3 20 of 39 Overloaded Operators and Type inference
A squaring function on integers:
Declaration Type
let square x = x * x int -> int Default
A squaring function on floats: square: float -> float
Declaration
let square(x:float) = x * x Type the argument
let square x:float = x * x Type the result
let square x = x * x: float Type expression for the result
let square x = x:float * x Type a variable
You can mix these possibilities
02157 Functional Programming, Week 3 20 of 39 Overloaded Operators and Type inference
A squaring function on integers:
Declaration Type
let square x = x * x int -> int Default
A squaring function on floats: square: float -> float
Declaration
let square(x:float) = x * x Type the argument
let square x:float = x * x Type the result
let square x = x * x: float Type expression for the result
let square x = x:float * x Type a variable
You can mix these possibilities
02157 Functional Programming, Week 3 20 of 39 Overloaded Operators and Type inference
A squaring function on integers:
Declaration Type
let square x = x * x int -> int Default
A squaring function on floats: square: float -> float
Declaration
let square(x:float) = x * x Type the argument
let square x:float = x * x Type the result
let square x = x * x: float Type expression for the result
let square x = x:float * x Type a variable
You can mix these possibilities
02157 Functional Programming, Week 3 20 of 39 Overloaded Operators and Type inference
A squaring function on integers:
Declaration Type
let square x = x * x int -> int Default
A squaring function on floats: square: float -> float
Declaration
let square(x:float) = x * x Type the argument
let square x:float = x * x Type the result
let square x = x * x: float Type expression for the result
let square x = x:float * x Type a variable
You can mix these possibilities
02157 Functional Programming, Week 3 20 of 39 Overloaded Operators and Type inference
A squaring function on integers:
Declaration Type
let square x = x * x int -> int Default
A squaring function on floats: square: float -> float
Declaration
let square(x:float) = x * x Type the argument
let square x:float = x * x Type the result
let square x = x * x: float Type expression for the result
let square x = x:float * x Type a variable
You can mix these possibilities
02157 Functional Programming, Week 3 20 of 39 Overloaded Operators and Type inference
A squaring function on integers:
Declaration Type
let square x = x * x int -> int Default
A squaring function on floats: square: float -> float
Declaration
let square(x:float) = x * x Type the argument
let square x:float = x * x Type the result
let square x = x * x: float Type expression for the result
let square x = x:float * x Type a variable
You can mix these possibilities
02157 Functional Programming, Week 3 20 of 39 Basic types: equality and comparison
Equality and comparison are defined for the basic types of F#, including integers,
floats, booleans, characters and strings.
Examples:
true < false;;
val it : bool = false
’a’ < ’A’;;
val it : bool = false
"a" < "ab";;
val it : bool = true
02157 Functional Programming, Week 3 21 of 39 Composite Types: equality and comparison
Equality and comparison carry over to composite types
as long as function types are not involved:
Equality is defined structurally on values with the same type:
[[1;2]; [3;4;5]] = [[1..2]; [3..5]];;
val it : bool = true
Comparison is typically defined using lexicographical ordering:
[1; 2; 3] < [1; 4];;
val it : bool = true
(2, [1; 2; 3]) > (2, [1;4]);;
val it : bool = false
02157 Functional Programming, Week 3 22 of 39 Composite Types: equality and comparison
Equality and comparison carry over to composite types
as long as function types are not involved:
Equality is defined structurally on values with the same type:
[[1;2]; [3;4;5]] = [[1..2]; [3..5]];;
val it : bool = true
Comparison is typically defined using lexicographical ordering:
[1; 2; 3] < [1; 4];;
val it : bool = true
(2, [1; 2; 3]) > (2, [1;4]);;
val it : bool = false
02157 Functional Programming, Week 3 22 of 39 Composite Types: equality and comparison
Equality and comparison carry over to composite types
as long as function types are not involved:
Equality is defined structurally on values with the same type:
[[1;2]; [3;4;5]] = [[1..2]; [3..5]];;
val it : bool = true
Comparison is typically defined using lexicographical ordering:
[1; 2; 3] < [1; 4];;
val it : bool = true
(2, [1; 2; 3]) > (2, [1;4]);;
val it : bool = false
02157 Functional Programming, Week 3 22 of 39 Tuples
An ordered collection of n values (v1, v2, . . . , vn) is called an n-tuple
Examples
(3, false);
val it = (3, false) : int * bool 2-tuples (pairs)
(1, 2, ("ab",true));
val it = (1, 2, ("ab", true)) : ?
3-tuples (triples)
Equality defined componentwise, ordering lexicographically
(1, 2.0, true) = (2-1, 2.0*1.0, 1<2);;
val it = true : bool
provided = is defined on components
02157 Functional Programming, Week 3 23 of 39 Tuples
An ordered collection of n values (v1, v2, . . . , vn) is called an n-tuple
Examples
(3, false);
val it = (3, false) : int * bool 2-tuples (pairs)
(1, 2, ("ab",true));
val it = (1, 2, ("ab", true)) : ?
3-tuples (triples)
Equality defined componentwise, ordering lexicographically
(1, 2.0, true) = (2-1, 2.0*1.0, 1<2);;
val it = true : bool
provided = is defined on components
02157 Functional Programming, Week 3 23 of 39 Tuple patterns
Extract components of tuples
let ((x,_),(_,y,_)) = ((1,true),("a","b",false));;
val x : int = 1
val y : string = "b"
Pattern matching yields bindings
Restriction
let (x,x) = (1,1);;
...
... ERROR ... ’x’ is bound twice in this pattern
Restriction can be circumvented using when clauses, for example:
let f = function
| (x,y) when x=y -> x
| (x,y) -> x+y
02157 Functional Programming, Week 3 24 of 39 Tuple patterns
Extract components of tuples
let ((x,_),(_,y,_)) = ((1,true),("a","b",false));;
val x : int = 1
val y : string = "b"
Pattern matching yields bindings
Restriction
let (x,x) = (1,1);;
...
... ERROR ... ’x’ is bound twice in this pattern
Restriction can be circumvented using when clauses, for example:
let f = function
| (x,y) when x=y -> x
| (x,y) -> x+y
02157 Functional Programming, Week 3 24 of 39 Tuple patterns
Extract components of tuples
let ((x,_),(_,y,_)) = ((1,true),("a","b",false));;
val x : int = 1
val y : string = "b"
Pattern matching yields bindings
Restriction
let (x,x) = (1,1);;
...
... ERROR ... ’x’ is bound twice in this pattern
Restriction can be circumvented using when clauses, for example:
let f = function
| (x,y) when x=y -> x
| (x,y) -> x+y
02157 Functional Programming, Week 3 24 of 39 Polymorphic types: equality and comparison constraints (I)
Polymorphic types may be accompanied with equality and comparison constraints
like:
• when ’a : comparison
• when ’b : equality
For example, there is a built-in function:
compare x y =



> 0 if x > y
0 if x = y
< 0 if x < y
with the type:
’a -> ’a -> int when ’a : comparison
For example:
compare (2, [1; 2; 3]) (2, [1;4]);;
val it : int = -1
02157 Functional Programming, Week 3 25 of 39 Polymorphic types: equality and comparison constraints (I)
Polymorphic types may be accompanied with equality and comparison constraints
like:
• when ’a : comparison
• when ’b : equality
For example, there is a built-in function:
compare x y =



> 0 if x > y
0 if x = y
< 0 if x < y
with the type:
’a -> ’a -> int when ’a : comparison
For example:
compare (2, [1; 2; 3]) (2, [1;4]);;
val it : int = -1
02157 Functional Programming, Week 3 25 of 39 Polymorphic types: equality and comparison constraints (II)
The built-in function List.contains can be declared as follows:
let rec contains x =
function
| [] -> false
| y::ys -> x=y || contains x ys
contains: ’a -> ’a list -> bool when ’a : equality
contains [3;4] [[1..2]; [3..5]];;
val it : bool = false
Notice:
• The equality constraint in the type
• Lazy (short-circuit) evaluation of e1||e2 causes termination as soon as an
element y equal to x is found
• Yet a recursion following the structure of lists
02157 Functional Programming, Week 3 26 of 39 Polymorphic types: equality and comparison constraints (II)
The built-in function List.contains can be declared as follows:
let rec contains x =
function
| [] -> false
| y::ys -> x=y || contains x ys
contains: ’a -> ’a list -> bool when ’a : equality
contains [3;4] [[1..2]; [3..5]];;
val it : bool = false
Notice:
• The equality constraint in the type
• Lazy (short-circuit) evaluation of e1||e2 causes termination as soon as an
element y equal to x is found
• Yet a recursion following the structure of lists
02157 Functional Programming, Week 3 26 of 39 On let-expressions and lists
02157 Functional Programming, Week 3 27 of 39 Let-expressions
A let-expression el has the (verbose) form
let x = e1 in e2
or the following short form exploiting indentation:
let x = e1
e2
The expression provides a local definition for x in e2.
A let-expression el is evaluated in an environment env as follows:
If
1 v1 is the value obtained by evaluating e1 in env,
2 env
′
is obtained by adding binding x 7→ v1 to env and
3 v2 is the value obtained by evaluating e2 in env
′
then
(let x = e1 in e2, env) ⇝ (v2, env)
02157 Functional Programming, Week 3 28 of 39 Let-expressions
A let-expression el has the (verbose) form
let x = e1 in e2
or the following short form exploiting indentation:
let x = e1
e2
The expression provides a local definition for x in e2.
A let-expression el is evaluated in an environment env as follows:
If
1 v1 is the value obtained by evaluating e1 in env,
2 env
′
is obtained by adding binding x 7→ v1 to env and
3 v2 is the value obtained by evaluating e2 in env
′
then
(let x = e1 in e2, env) ⇝ (v2, env)
02157 Functional Programming, Week 3 28 of 39 Let-expressions
A let-expression el has the (verbose) form
let x = e1 in e2
or the following short form exploiting indentation:
let x = e1
e2
The expression provides a local definition for x in e2.
A let-expression el is evaluated in an environment env as follows:
If
1 v1 is the value obtained by evaluating e1 in env,
2 env
′
is obtained by adding binding x 7→ v1 to env and
3 v2 is the value obtained by evaluating e2 in env
′
then
(let x = e1 in e2, env) ⇝ (v2, env)
02157 Functional Programming, Week 3 28 of 39 Let-expressions
A let-expression el has the (verbose) form
let x = e1 in e2
or the following short form exploiting indentation:
let x = e1
e2
The expression provides a local definition for x in e2.
A let-expression el is evaluated in an environment env as follows:
If
1 v1 is the value obtained by evaluating e1 in env,
2 env
′
is obtained by adding binding x 7→ v1 to env and
3 v2 is the value obtained by evaluating e2 in env
′
then
(let x = e1 in e2, env) ⇝ (v2, env)
02157 Functional Programming, Week 3 28 of 39 Let-expressions
A let-expression el has the (verbose) form
let x = e1 in e2
or the following short form exploiting indentation:
let x = e1
e2
The expression provides a local definition for x in e2.
A let-expression el is evaluated in an environment env as follows:
If
1 v1 is the value obtained by evaluating e1 in env,
2 env′
is obtained by adding binding x 7→ v1 to env and
3 v2 is the value obtained by evaluating e2 in env
′
then
(let x = e1 in e2, env) ⇝ (v2, env)
02157 Functional Programming, Week 3 28 of 39 Let-expressions
A let-expression el has the (verbose) form
let x = e1 in e2
or the following short form exploiting indentation:
let x = e1
e2
The expression provides a local definition for x in e2.
A let-expression el is evaluated in an environment env as follows:
If
1 v1 is the value obtained by evaluating e1 in env,
2 env′
is obtained by adding binding x 7→ v1 to env and
3 v2 is the value obtained by evaluating e2 in env′
then
(let x = e1 in e2, env) ⇝ (v2, env)
02157 Functional Programming, Week 3 28 of 39 Let-expressions
A let-expression el has the (verbose) form
let x = e1 in e2
or the following short form exploiting indentation:
let x = e1
e2
The expression provides a local definition for x in e2.
A let-expression el is evaluated in an environment env as follows:
If
1 v1 is the value obtained by evaluating e1 in env,
2 env′
is obtained by adding binding x 7→ v1 to env and
3 v2 is the value obtained by evaluating e2 in env′
then
(let x = e1 in e2, env) ⇝ (v2, env)
02157 Functional Programming, Week 3 28 of 39 Let-expression – an example
let g y = let a = 6
let b = y + a
y + b;;
val g : int -> int
g 1;;
val it : int = 8
Note: a and b are not visible outside of g
Evaluation ?
02157 Functional Programming, Week 3 29 of 39 Let-expression – an example
let g y = let a = 6
let b = y + a
y + b;;
val g : int -> int
g 1;;
val it : int = 8
Note: a and b are not visible outside of g
Evaluation ?
02157 Functional Programming, Week 3 29 of 39 Pattern matching on results of recursive calls
sumProd [x0;x1; . . .;xn−1]
= ( x0 + x1 + . . . + xn−1 , x0 * x1 * . . . * xn−1 )
sumProd [] = (0,1)
The declaration is based on the recursion formula:
sumProd [x0;x1; . . . ;xn−1] = (x0 + rSum,x0 * rProd)
where (rSum,rProd) = sumProd [x1; . . . ;xn−1]
This gives the declaration:
let rec sumProd =
function
| [] -> (0,1)
| x::rest -> let (rSum,rProd) = sumProd rest
(x+rSum,x*rProd);;
val sumProd : int list -> int * int
sumProd [2;5];;
val it : int * int = (7, 10)
02157 Functional Programming, Week 3 30 of 39 Pattern matching on results of recursive calls
sumProd [x0;x1; . . .;xn−1]
= ( x0 + x1 + . . . + xn−1 , x0 * x1 * . . . * xn−1 )
sumProd [] = (0,1)
The declaration is based on the recursion formula:
sumProd [x0;x1; . . . ;xn−1] = (x0 + rSum,x0 * rProd)
where (rSum,rProd) = sumProd [x1; . . . ;xn−1]
This gives the declaration:
let rec sumProd =
function
| [] -> (0,1)
| x::rest -> let (rSum,rProd) = sumProd rest
(x+rSum,x*rProd);;
val sumProd : int list -> int * int
sumProd [2;5];;
val it : int * int = (7, 10)
02157 Functional Programming, Week 3 30 of 39 Pattern matching on results of recursive calls
sumProd [x0;x1; . . .;xn−1]
= ( x0 + x1 + . . . + xn−1 , x0 * x1 * . . . * xn−1 )
sumProd [] = (0,1)
The declaration is based on the recursion formula:
sumProd [x0;x1; . . . ;xn−1] = (x0 + rSum,x0 * rProd)
where (rSum,rProd) = sumProd [x1; . . . ;xn−1]
This gives the declaration:
let rec sumProd =
function
| [] -> (0,1)
| x::rest -> let (rSum,rProd) = sumProd rest
(x+rSum,x*rProd);;
val sumProd : int list -> int * int
sumProd [2;5];;
val it : int * int = (7, 10)
02157 Functional Programming, Week 3 30 of 39 A blackboard exercise
A function from the List library:
• List.unzip([(x0, y0);(x1, y1); . . . ;(xn−1, yn−1)]
= ([x0;x1; . . . ;xn−1],[y0;y1; . . . ;yn−1])
02157 Functional Programming, Week 3 31 of 39 The Syntax unlocked so far:
Expressions
An expression can be any of the following:
• A constant
• An identifier
• If e, e1, . . . en are expressions and ⊕ is an infix operator (like +, ∗, <, =,...),
p1, . . . , pn are patterns, cs is a set of pattern matching clauses, and d is a
declaration, then also the following are expressions:
⋆ e1 ⊕ e2
⋆ if e then e1 else e2
⋆ (e)
⋆ e1 e2
⋆ (e1, . . . , en)
⋆ match e with cs
⋆ fun p1 p2 . . . pn → e
⋆ function cs
⋆ d in e
⋆ [ ]
⋆ e1::e2
02157 Functional Programming, Week 3 32 of 39 The Syntax unlocked so far:
Patterns
A pattern can be any of the following:
• A constant
• An identifier
• The wildcard
• If p1, . . . pn are patterns and e and expression, then also the following are
patterns:
⋆ (p1, . . . , pn)
⋆ p1 | p2
⋆ []
⋆ p1::p2
⋆ p1 when e
Pattern matching clauses
If p1, . . . , pn are patterns and e1, . . . , en are expressions then the following forms a
set of pattern matching clauses:
| p1 → e1
. . .
| pn → en
02157 Functional Programming, Week 3 33 of 39 The Syntax unlocked so far:
Declarations
If e is an expression and f is an identifier, and p1, . . . , pn (n ≥ 0) are patterns then
the following are declarations:
• let f p1 . . . pn = e
• let rec f p1 . . . pn = e
02157 Functional Programming, Week 3 34 of 39 What is the value of a?
Consider
let pi = 3.14;;
let ca r = pi * r * r;;
let a = let pi = 1.0;;
ca 1.0;;
a?
02157 Functional Programming, Week 3 35 of 39 Semantics of a function: A closure
Consider a declaration of f in an environment env = [a 7→ 4, b 7→ true]:
let f x = x+a
The resulting environment is:
[a 7→ 4, b 7→ true, f 7→ clf ]
where the value of f is a closure clf =
([x], x + a, [a 7→ 4])
consisting of
• the argument list: [x]
• the body of f: x+a
• the environment with bindings for the free variables: [a 7→ 4]
The bindings in a closure’s environment are determined at the place where the
function is declared static binding
02157 Functional Programming, Week 3 36 of 39 Semantics of a function: A closure
Consider a declaration of f in an environment env = [a 7→ 4, b 7→ true]:
let f x = x+a
The resulting environment is:
[a 7→ 4, b 7→ true, f 7→ clf ]
where the value of f is a closure clf =
([x], x + a, [a 7→ 4])
consisting of
• the argument list: [x]
• the body of f: x+a
• the environment with bindings for the free variables: [a 7→ 4]
The bindings in a closure’s environment are determined at the place where the
function is declared static binding
02157 Functional Programming, Week 3 36 of 39 Semantics of a function: A closure
Consider a declaration of f in an environment env = [a 7→ 4, b 7→ true]:
let f x = x+a
The resulting environment is:
[a 7→ 4, b 7→ true, f 7→ clf ]
where the value of f is a closure clf =
([x], x + a, [a 7→ 4])
consisting of
• the argument list: [x]
• the body of f: x+a
• the environment with bindings for the free variables: [a 7→ 4]
The bindings in a closure’s environment are determined at the place where the
function is declared static binding
02157 Functional Programming, Week 3 36 of 39 Semantics of a function: A closure
Consider a declaration of f in an environment env = [a 7→ 4, b 7→ true]:
let f x = x+a
The resulting environment is:
[a 7→ 4, b 7→ true, f 7→ clf ]
where the value of f is a closure clf =
([x], x + a, [a 7→ 4])
consisting of
• the argument list: [x]
• the body of f: x+a
• the environment with bindings for the free variables: [a 7→ 4]
The bindings in a closure’s environment are determined at the place where the
function is declared static binding
02157 Functional Programming, Week 3 36 of 39 Function application
Let env be an environment, where the closure for f is
clf = ([x], e, envf )
The application f (a) is evaluated as follows in env:
(f (a), env)
⇝ (e, [x 7→ v] + envf )
where
• v is the value of a in env
• [x 7→ v] + envf is the environment obtained by adding the binding from x 7→ v
to envf .
02157 Functional Programming, Week 3 37 of 39 Function application
Let env be an environment, where the closure for f is
clf = ([x], e, envf )
The application f (a) is evaluated as follows in env:
(f (a), env)
⇝ (e, [x 7→ v] + envf )
where
• v is the value of a in env
• [x 7→ v] + envf is the environment obtained by adding the binding from x 7→ v
to envf .
02157 Functional Programming, Week 3 37 of 39 Function application
Let env be an environment, where the closure for f is
clf = ([x], e, envf )
The application f (a) is evaluated as follows in env:
(f (a), env)
⇝ (e, [x 7→ v] + envf )
where
• v is the value of a in env
• [x 7→ v] + envf is the environment obtained by adding the binding from x 7→ v
to envf .
02157 Functional Programming, Week 3 37 of 39 Function application
Let env be an environment, where the closure for f is
clf = ([x], e, envf )
The application f (a) is evaluated as follows in env:
(f (a), env)
⇝ (e, [x 7→ v] + envf )
where
• v is the value of a in env
• [x 7→ v] + envf is the environment obtained by adding the binding from x 7→ v
to envf .
02157 Functional Programming, Week 3 37 of 39 Static binding: an example
Consider
let pi = 3.14;;
env1 = ?
let ca r = pi * r * r;;
env2 = ?
let a = let pi = 1.0
env3 = ?
ca 1.0;;
env4 = ?
a?
02157 Functional Programming, Week 3 38 of 39 Exercises
• Some programming exercises: HR 4.3, 4.8, 4.9, 4.12
• Some exercises that are supposed to be done on paper: HR 4.16, 4.17
⋆ Derive the type of the given functions like we have done in the lecture.
Of course, the F# interpreter could also compute the type automatically, but the
task is to give the inference steps like in the lecture.
⋆ Try to understand how each function works and how the given expression
evaluates.
Also here one could use the F# interpreter to compute it for some concrete input
lists, but the task is to obtain a short description of the evaluation for generic
lists like [x0; . . . ; xn−1].
02157 Functional Programming, Week 3 39 of 39