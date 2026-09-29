[Page 1]02157 Functional Programming, Week 1
02157 Functional Programming
Week 1:
Introduction and Getting Started
Sebastian Mödersheim
Based on slides by Michael Reichhardt Hansen
September 4, 2026
1 of 39

[Page 2]WELCOME to
02157 Functional Programming
Teacher: Sebastian Mödersheim, DTU Compute
Teaching assistants:
Andrei Chiosa
Elias Haynie-Gay
Emil Breinholt
Jacob Eskild Jensen
Jóhannes Sigvardsen
Teaching Assistant Plus
on our DTU Learn page/classlist
Homepage: www.compute.dtu.dk/courses/02157
samo@dtu.dk
02157 Functional Programming, Week 1
2 of 39

[Page 3]These Slides
I have taken over this course last year.
These slides are based on slides by Michael R. Hansen
who taught the course in the previous years.
By default you should assume that
 everything great on these slides is due to Michael and
• everything that sucks is probably my fault. :-)
Please let me know if you find errors or if anything is unclear.
02157 Functional Programming, Week 1
3 of 39

[Page 4]Functional Programming (FP) is Awesome
• Mathematical way of programming
★ abstract, succinct, precise, no mess
 easier to write, to read, and to extend
 speed of development, less debugging time
★ quality of code: fewer bugs and security problems
02157 Functional Programming, Week 1
4 of 39

[Page 5]Functional Programming (FP) is Awesome
• Mathematical way of programming
★ abstract, succinct, precise, no mess
★ easier to write, to read, and to extend
★ speed of development, less debugging time
★ quality of code: fewer bugs and security problems
• Programming Language Concepts: FP is extremely helpful for:
★ compiler design and theoretical computer science (02141 Computer Science
Modeling, 02247 Compiler Construction)
★ formal verification (02242 Program Analysis, 02244 Logic for Security)
★ theorem proving (02256 Automated Reasoning)
02157 Functional Programming, Week 1
4 of 39

[Page 6]Functional Programming (FP) is Awesome
• Mathematical way of programming
★ abstract, succinct, precise, no mess
★ easier to write, to read, and to extend
★ speed of development, less debugging time
★ quality of code: fewer bugs and security problems
• Programming Language Concepts: FP is extremely helpful for:
★ compiler design and theoretical computer science (02141 Computer Science
Modeling, 02247 Compiler Construction)
★ formal verification (02242 Program Analysis, 02244 Logic for Security)
★ theorem proving (02256 Automated Reasoning)
• Transfer: An FP background helps also when using a conventional language
★ You can use FP concepts to systematically write better imperative code
★ Conventional programming languages incrementally adopt features from FP
e.g. higher-order functions, algebraic data types, automatic type inference, ...
02157 Functional Programming, Week 1
4 of 39

[Page 7]Functional Programming (FP) is Awesome
• Mathematical way of programming
★ abstract, succinct, precise, no mess
★ easier to write, to read, and to extend
★ speed of development, less debugging time
★ quality of code: fewer bugs and security problems
• Programming Language Concepts: FP is extremely helpful for:
★ compiler design and theoretical computer science (02141 Computer Science
Modeling, 02247 Compiler Construction)
★ formal verification (02242 Program Analysis, 02244 Logic for Security)
★ theorem proving (02256 Automated Reasoning)
• Transfer: An FP background helps also when using a conventional language
★ You can use FP concepts to systematically write better imperative code
★ Conventional programming languages incrementally adopt features from FP
e.g. higher-order functions, algebraic data types, automatic type inference, ...
• Senior Programmers
★ Al is getting more and more powerful in programming
We need human supervisors of Al who can
Understand programming concepts, planning, structuring
Understand the produced code and its quality
Verify/prove that solutions are correct and secure
02157 Functional Programming, Week 1
4 of 39

[Page 8]Functional Programming (FP) is Awesome
• Mathematical way of programming
★ abstract, succinct, precise, no mess
★ easier to write, to read, and to extend
★ speed of development, less debugging time
★ quality of code: fewer bugs and security problems
• Programming Language Concepts: FP is extremely helpful for:
★ compiler design and theoretical computer science (02141 Computer Science
Modeling, 02247 Compiler Construction)
★ formal verification (02242 Program Analysis, 02244 Logic for Security)
★ theorem proving (02256 Automated Reasoning)
• Transfer: An FP background helps also when using a conventional language
★ You can use FP concepts to systematically write better imperative code
★ Conventional programming languages incrementally adopt features from FP
e.g. higher-order functions, algebraic data types, automatic type inference, ...
• Senior Programmers
★ Al is getting more and more powerful in programming
★ We need human supervisors of Al who can
Understand programming concepts, planning, structuring
Understand the produced code and its quality
Verify/prove that solutions are correct and secure
• Invest the Time!
It requires a lot of time to become good at FP
You need to do exercises
a lot!
It will be an excellent investment: you will get a pro programmer!
It will be a lot of fun!
02157 Functional Programming, Week 1
4 of 39

[Page 9]Plan for Today
 The concepts of functional programming
 Organizational matters
 Introduction to $F\#$
 Lists
02157 Functional Programming, Week 1
5 of 39

[Page 10]The Concepts of Functional Programming
Note: We will sometimes work on the blackboard. I will take pictures after the
lecture and upload them to DTU Learn.
Example: contrasting 3 ways to write exponentiation:

| Mathematical Definition   | Functional Program   | Imperative Program   |
| :--- | :--- | :--- |

Summary:
• Functional programming is close to mathematical descriptions.
Recursion instead of loops
★ Variables are like variables in math
• It is often much easier to write correct programs, prove their correctness, and to
read and extend them.
• It is often easier to write asymptotically efficient programs.
• We will see how to transform recusion into loops.
• Functional programming knowledge can help you
even when you are forced to use an imperative language.
02157 Functional Programming, Week 1
6 of 39

[Page 11]There is no magic
It is possible to understand everything:
02157 Functional Programming, Week 1
7 of 39

[Page 12]There is no magic
It is possible to understand everything:
• The syntax (notation) of the programming language
02157 Functional Programming, Week 1
7 of 39

[Page 13]There is no magic
It is possible to understand everything:
 The syntax (notation) of the programming language
• The semantics (meaning) of programs
02157 Functional Programming, Week 1
7 of 39

[Page 14]There is no magic
It is possible to understand everything:
• The syntax (notation) of the programming language
• The semantics (meaning) of programs
• The evaluation of programs
02157 Functional Programming, Week 1
7 of 39

[Page 15]There is no magic
It is possible to understand everything:
• The syntax (notation) of the programming language
• The semantics (meaning) of programs
• The evaluation of programs
• The properties of programs
02157 Functional Programming, Week 1
7 of 39

[Page 16]There is no magic
It is possible to understand everything:
• The syntax (notation) of the programming language
• The semantics (meaning) of programs
• The evaluation of programs
• The properties of programs
Functional programming is a simple setting supporting
 declaration of clear, concise programs at a high level of abstraction
• understanding and analysis of programs
due to the basis on mathematical functions (no side-effects)
02157 Functional Programming, Week 1
7 of 39

[Page 17]Some functional programming background
• The A-calculus was introduced around 1930 by Church and Kleene when
investigating function definition, function application, recursion and computable
functions. For example, $f(x)=x+2$ is represented by $\lambda x.x+2$.
★ We will look in more detail at the  -calculus in one lecture.
02157 Functional Programming, Week 1
8 of 39

[Page 18]Some functional programming background
• The A-calculus was introduced around 1930 by Church and Kleene when
investigating function definition, function application, recursion and computable
functions. For example, $f(x)=x+2$ is represented by $\lambda x.x+2$.
★ We will look in more detail at the  -calculus in one lecture.
• The untyped functional-like programming language LISP was developed by
McCarthy in the late 1950s.
02157 Functional Programming, Week 1
8 of 39

[Page 19]Some functional programming background
• The A-calculus was introduced around 1930 by Church and Kleene when
investigating function definition, function application, recursion and computable
functions. For example, $f(x)=x+2$ is represented by $\lambda x.x+2$.
★ We will look in more detail at the  -calculus in one lecture.
• The untyped functional-like programming language LISP was developed by
McCarthy in the late 1950s.
• Functional languages with a strong type system like ML (by Milner) were
introduced in the 1970s.
02157 Functional Programming, Week 1
8 of 39

[Page 20]Some functional programming background
• The A-calculus was introduced around 1930 by Church and Kleene when
investigating function definition, function application, recursion and computable
functions. For example, $f(x)=x+2$ is represented by $\lambda x.x+2$.
★ We will look in more detail at the  -calculus in one lecture.
• The untyped functional-like programming language LISP was developed by
McCarthy in the late 1950s.
• Functional languages with a strong type system like ML (by Milner) were
introduced in the 1970s.
• Functional languages (SML, Haskell, OCAML, F#, ...) have now applications
far away from their origin: Compilers, Artificial Intelligence, Web-applications,
Financial sector,
02157 Functional Programming, Week 1
8 of 39

[Page 21]Some functional programming background
• The A-calculus was introduced around 1930 by Church and Kleene when
investigating function definition, function application, recursion and computable
functions. For example, $f(x)=x+2$ is represented by $\lambda x.x+2$.
★ We will look in more detail at the  -calculus in one lecture.
• The untyped functional-like programming language LISP was developed by
McCarthy in the late 1950s.
• Functional languages with a strong type system like ML (by Milner) were
introduced in the 1970s.
• Functional languages (SML, Haskell, OCAML, F#, ...) have now applications
far away from their origin: Compilers, Artificial Intelligence, Web-applications,
Financial sector,
• Declarative aspects are now sneaking into "main stream languages"
02157 Functional Programming, Week 1
8 of 39

[Page 22]Some functional programming background
• The A-calculus was introduced around 1930 by Church and Kleene when
investigating function definition, function application, recursion and computable
functions. For example, $f(x)=x+2$ is represented by $\lambda x.x+2$.
★ We will look in more detail at the  -calculus in one lecture.
• The untyped functional-like programming language LISP was developed by
McCarthy in the late 1950s.
• Functional languages with a strong type system like ML (by Milner) were
introduced in the 1970s.
• Functional languages (SML, Haskell, OCAML, F#, ...) have now applications
far away from their origin: Compilers, Artificial Intelligence, Web-applications,
Financial sector,
• Declarative aspects are now sneaking into "main stream languages"
• Functional programming should be a mandatory element of every BSc.
education in Computer Science according to ACM's and IEEE's curricula
recommendations, 2013.
02157 Functional Programming, Week 1
8 of 39

[Page 23]Have a look at
$\bullet http://homepages.inf.ed.ac.uk/wadler/realworld/$
• https://fsharp.org/testimonials/
concerning use of functional programming in the "real world".
02157 Functional Programming, Week 1
9 of 39

[Page 24]Part 2 - Practical Matters
• General information: http://courses.compute.dtu.dk/02157
02157 Functional Programming, Week 1
10 of 39

[Page 25]Part 2 - Practical Matters
• General information: http://courses.compute.dtu.dk/02157
• Practical Information:
http://courses.compute.dtu.dk/02157/PracticalInfo.html
02157 Functional Programming, Week 1
10 of 39

[Page 26]Part 2 - Practical Matters
• General information: http://courses.compute.dtu.dk/02157
• Practical Information:
http://courses.compute.dtu.dk/02157/PracticalInfo.html
• Course plan:
http://courses.compute.dtu.dk/02157/plan.html
02157 Functional Programming, Week 1
10 of 39

[Page 27]Part 2 - Practical Matters
• General information: http://courses.compute.dtu.dk/02157
• Practical Information:
http://courses.compute.dtu.dk/02157/PracticalInfo.html
• Course plan:
http://courses.compute.dtu.dk/02157/plan.html
• Exam form: Written exam 4 hours
Aid: all aid - without internet access
meaning that in addition to written aids, it is also permitted to bring a laptop,
tablet, and similar devices. The use of generative Al is not allowed.
Exam date: 16. December 2026 (E4B)
02157 Functional Programming, Week 1
10 of 39

[Page 28]Course Structure
• Weekly lectures Fridays 8:00-10:00
in 308 auditorium 012
• Weekly exercises with fantastic TAs Fridays 10:00-12:00
in 308 group rooms 001,009,017,127
Course design is based on an evenly distributed workload and "steady progress"
throughout the semester
02157 Functional Programming, Week 1
11 of 39

[Page 29]Course Structure
• Weekly lectures Fridays 8:00-10:00
in 308 auditorium 012
• Weekly exercises with fantastic TAs Fridays 10:00-12:00
in 308 group rooms 001,009,017,127
Course design is based on an evenly distributed workload and "steady progress"
throughout the semester
This course had about 30% failure rate in the exam for many years.
02157 Functional Programming, Week 1
11 of 39

[Page 30]Course Structure
• Weekly lectures Fridays 8:00-10:00
in 308 auditorium 012
• Weekly exercises with fantastic TAs Fridays 10:00-12:00
in 308 group rooms 001,009,017,127
Course design is based on an evenly distributed workload and "steady progress"
throughout the semester
This course had about 30% failure rate in the exam for many years.
I would like to change that.
• FP is not easy, but everybody can do it!
• It requires that you invest the time
★ Attend the lectures; if you cannot attend, see that you review the material
$(slides/book)$
★ Attend the exercises; you cannot learn it without doing it
★ Ask the TAs and me questions
You can also hand in solutions to exercises to the TAs if you want feedback
★ We often review in the lecture the exercises from the last week. Ask questions!
• Programming on paper:
★ Instead of trying around in the interpreter, it is often helpful to develop it "dry"
on paper first.
02157 Functional Programming, Week 1
11 of 39

[Page 31]Course Structure
• Weekly lectures Fridays 8:00-10:00
in 308 auditorium 012
• Weekly exercises with fantastic TAs Fridays 10:00-12:00
in 308 group rooms 001,009,017,127
Course design is based on an evenly distributed workload and "steady progress"
throughout the semester
This course had about 30% failure rate in the exam for many years.
I would like to change that.
• FP is not easy, but everybody can do it!
• It requires that you invest the time
★ Attend the lectures; if you cannot attend, see that you review the material
$(slides/book)$
★ Attend the exercises; you cannot learn it without doing it
★ Ask the TAs and me questions
You can also hand in solutions to exercises to the TAs if you want feedback
★ We often review in the lecture the exercises from the last week. Ask questions!
• Programming on paper:
★ Instead of trying around in the interpreter, it is often helpful to develop it "dry"
on paper first.
You are always welcome to visit my office: Building 322, Room 212
02157 Functional Programming, Week 1
11 of 39

[Page 32]-
Part 3  Introduction to F#
• The interactive environment
• Values, expressions, types, patterns
• Declarations of values and recursive functions
• Binding, environment and evaluation
• Type inference
02157 Functional Programming, Week 1
Main ingredients of F#
12 of 39

[Page 33]The Interactive Environment
$2*3+4;$;;
$val~it:int=10$
02157 Functional Programming, Week 1
13 of 39

[Page 34]The Interactive Environment
$2*3+4$;;
$val~it:int=10$
02157 Functional Programming, Week 1
Input to the F# system
Answer from the F# system
13 of 39

[Page 35]$2*3+4$;;
The Interactive Environment
val it: $int=10$
Input to the F# system
Answer from the F# system
• The keyword val indicates a value is computed
• The integer 10 is the computed value
• int is the type of the computed value
• The identifier it names the (last) computed value
02157 Functional Programming, Week 1
13 of 39

[Page 36]$2*3+4$;;
The Interactive Environment
val it: $int=10$
Input to the F# system
Answer from the F# system
• The keyword val indicates a value is computed
• The integer 10 is the computed value
• int is the type of the computed value
• The identifier it names the (last) computed value
Notion of a Binding: binding an identifier to a value.
$it\mapsto10$ reads: "it is bound to 10"
02157 Functional Programming, Week 1
13 of 39

[Page 37]Value Declarations
A value declaration has the form: let identifier = expression
let price $=25*5$;;
val price : int = 125
A declaration as input
Answer from the F# system
The effect of a declaration is a binding: price 125
02157 Functional Programming, Week 1
14 of 39

[Page 38]Value Declarations
A value declaration has the form: let identifier = expression
let price $=25*5$;;
val price : int = 125
A declaration as input
Answer from the F# system
The effect of a declaration is a binding: price 125
Bound identifiers can be used in expressions and declarations, e.g.
let newPrice = 2*price;;
val newPrice: int $=250$
newPrice > 500;;
val it: bool = false
02157 Functional Programming, Week 1
14 of 39

[Page 39]Value Declarations
A value declaration has the form: let identifier = expression
let price $=25*5$;;
val price : $int=125$
A declaration as input
Answer from the F# system
The effect of a declaration is a binding: price 125
Bound identifiers can be used in expressions and declarations, e.g.
let newPrice = 2*price;;
A collection of bindings
val newPrice: $int=250$
price
125
newPrice
250
newPrice > 500;;
it
false
val it: bool = false
is called an environment
02157 Functional Programming, Week 1
14 of 39

[Page 40]Function Declarations 1: let $f\times=e$
x is called the formal parameter
• the defining expression e is called the body of the declaration
02157 Functional Programming, Week 1
15 of 39

[Page 41]Function Declarations 1: let $f\times=e$
x is called the formal parameter
• the defining expression e is called the body of the declaration
Declaration of the circle area function:
let circleArea $r=$ System.Math.PI $PI*r*r$;;
• System. Math is a program library
• PI is an identifier (with type float) for in System.Math
$\pi$
The type is automatically inferred in the answer:
val circleArea : float -> float
Note: functions are also considered as values (but cannot be printed)
02157 Functional Programming, Week 1
15 of 39

[Page 42]Function Declarations 1: let $f\times=e$
x is called the formal parameter
• the defining expression e is called the body of the declaration
Declaration of the circle area function:
let circleArea $r=$ System.Math.PI $PI*r*r$;;
• System. Math is a program library
• PI is an identifier (with type float) for $\pi$ in System.Math
The type is automatically inferred in the answer:
val circleArea : float -> float
Note: functions are also considered as values (but cannot be printed)
Applications of the function (aka function call):
circleArea 1.0  ; (* this is a comment *
val it: float = 3.141592654
circleArea (3.2);; // A comment: optional brackets
val it: float = 32.16990877
1.0 and 3.2 are also called actual parameters
02157 Functional Programming, Week 1
15 of 39

[Page 43]Syntax, Type Checking, and Semantics
• The syntax of a programming language describes what sequences of characters
consitute a correctly formed program,
★ e.g. balancing of opening and closing parentheses.
• Type checking checks that all values (including functions) used in the program
are indeed defined and used with the correct types,
★ e.g. a function that expects an int cannot be called with a string.
• Semantics says what a syntactically correct, well-typed program means.
 e.g. if $x>0$ then x else $2*x$ with $[x\mapsto-3]$ evaluates to -6.
• In 02141 Computer Science Modelling you will learn how to formally describe
syntax and semantics of programming languages.
• During the course, we will make such descriptions for reference, but not in all
details formally. You will not be asked in the exam to describe syntax or
semantics of F#.
02157 Functional Programming, Week 1
16 of 39

[Page 44]Constants
The Syntax unlocked so far $(1/2)$:
• int constants like 0, 1, -1, ...
• float constants like 0.0, 3.14, ...
• Later: string constants like "Hello" and bool constants true and false
Identifiers
like x or exp are sequences of alphanumberic characters, i.e. letters and digits,
where the first must be a letter.
Expressions
can be any of the following:
• A constant
• An identifier like x
• If e, $e_{1},...e_{n}$ are expressions and is an infix operator $(like+,*,<,=,...),$
then also the following are expressions:
e1e2
if e then $e_{1}$ else $e_{2}$
(e)
e1 e2
$*(e_{1},...,e_{n})$
02157 Functional Programming, Week 1
17 of 39

[Page 45]The Syntax unlocked so far $(2/2)$:
Declarations
If e is an expression and f and $x_{1},...,x_{n}$ are identifiers, then the following are
declarations:
• let $f=e$
• let $f(x_{1},...,x_{n})=e$
where the x; may occur in e.
and the following are recursive declarations:
 let rec $f=e$
 let rec $f(x_{1},...,x_{n})=e$
where also f may occur in e
02157 Functional Programming, Week 1
18 of 39

[Page 46]The power function defined earlier:
let rec power $(x,n)=$
if $(n=0)$ then 1.0
else x * power(x,n-1)
Patterns
02157 Functional Programming, Week 1
19 of 39

[Page 47]Patterns
The power function defined earlier:
let rec power $(x,n)=$
if $(n=0)$ then 1.0
else x * power(x,n-1)
An equivalent definition is using pattern matching:
let rec power(x,n) =
match (x,n) with
| $(_{-},0)->1.0$
| $(x,n)\rightarrow x*power(x,n-1)$
(*1*)
(* 2 *)
• The first pattern ( ,0) is matches an arbitrary value for x but only 0 for n.
• The second pattern (x, n) matches any value (x, n).
• The second pattern is only tried if the first one does not match, thus it catches
all other cases.
02157 Functional Programming, Week 1
19 of 39

[Page 48]Patterns
Patterns
can be any of the following:
• A constant
• An identifier like x
• The wildcard
• And if $p_{1},...p_{n}$ are patterns,
then also $(p_{1},...,p_{n})$
Expressions
An Expression can also be (in addition to
what we allowed before):
match e with
 $p_{1}\rightarrow e_{1}$
 $|p_{n}\rightarrow e_{n}$
if $p_{1},...,p_{n}$ are patterns and e $,e_{1},...,e_{n}$
are expressions.
Examples:
02157 Functional Programming, Week 1
20 of 39

[Page 49]Patterns
Patterns
can be any of the following:
• A constant
• An identifier like x
• The wildcard
• And if $p_{1},...p_{n}$ are patterns,
then also $(p_{1},...,p_{n})$
Examples:
Expressions
An Expression can also be (in addition to
what we allowed before):
match e with
$p_{1}\rightarrow e_{1}$
$|p_{n}\rightarrow e_{n}$
if $p_{1},...,p_{n}$ are patterns and e $,e_{1},...,e_{n}$
are expressions.
• Value 3.1 matches pattern x resulting in environment: $[x\mapsto3.1]$
02157 Functional Programming, Week 1
20 of 39

[Page 50]Patterns
Patterns
can be any of the following:
• A constant
• An identifier like x
• The wildcard
• And if $p_{1},...p_{n}$ are patterns,
then also $(p_{1},...,p_{n})$
Examples:
Expressions
An Expression can also be (in addition to
what we allowed before):
match e with
$p_{1}\rightarrow e_{1}$
$|p_{n}\rightarrow e_{n}$
if $p_{1},...,p_{n}$ are patterns and e $,e_{1},...,e_{n}$
are expressions.
• Value 3.1 matches pattern x resulting in environment: $[x\mapsto3.1]$
• Value true matches pattern true resulting in environment []
02157 Functional Programming, Week 1
20 of 39

[Page 51]Patterns
Patterns
can be any of the following:
• A constant
• An identifier like x
• The wildcard
• And if $p_{1},...p_{n}$ are patterns,
then also $(p_{1},...,p_{n})$
Examples:
Expressions
An Expression can also be (in addition to
what we allowed before):
match e with
 $p_{1}\rightarrow e_{1}$
$|\rho_{n}\rightarrow e_{n}$
if $p_{1},...,p_{n}$ are patterns and e $,e_{1},...,e_{n}$
are expressions.
• Value 3.1 matches pattern x resulting in environment: $[x\mapsto3.1]$
• Value true matches pattern true resulting in environment []
• The pair (1, true) matches pattern (x, y) resulting in environment
$[x\mapsto1,y\mapsto true]$
02157 Functional Programming, Week 1
20 of 39

[Page 52]Match expressions
A match expression match e with is evaluated as follows:
| $p_{1}\rightarrow e_{1}$
:
$p_{n}\rightarrow e_{n}$
1 evaluate e to a value, say v
 search for the first pattern $p_{i}$ matching v
 evaluate $e_{i}$ in an environment enriched with the bindings from the pattern
matching
02157 Functional Programming, Week 1
21 of 39

[Page 53]Match expressions
A match expression match e with is evaluated as follows:
| $p_{1}\rightarrow e_{1}$
:
$p_{n}\rightarrow e_{n}$
1 evaluate e to a value, say v
 search for the first pattern $p_{i}$ matching v
 evaluate $e_{i}$ in an environment enriched with the bindings from the pattern
matching
If no pattern matches v, then the evaluation terminates with an error.
02157 Functional Programming, Week 1
21 of 39

[Page 54]Example: Match on a pair
match (3+5, 3<5) with
|
(0,
)
-> 0
|
(n,false)
-> -n
|
(n, )
-> $2*n$
02157 Functional Programming, Week 1
22 of 39

[Page 55]Example: Match on a pair
match $(3+5$, 3<5) with
|
(0,
)
-> 0
|
(n,false)
-> -n
|
(n, )
->
$2*n$
match (8, true)
with
|
(0, )
-> 0
|
(n,false)
-> -n
|
(n, )
-> $2*n$
02157 Functional Programming, Week 1
22 of 39

[Page 56]Example: Match on a pair
match $(3+5$,
$3<5.$) with
|
(0,
)
-> 0
|
(n,false)
-> -n
|
(n, )
->
$2*n$
match (8, true)
with
|
(0,
)
-> 0
|
(n,false)
-> -n
|
(n, )
-> $2*n$
match (8, true)
with
|
(n,false)
-> -n
|
(n, )
-> $2*n$
02157 Functional Programming, Week 1
22 of 39

[Page 57]Example: Match on a pair
match $(3+5$,
$3<5$) with
|
(0,
)
-> 0
|
(n,false)
-> -n
|
(n, )
->
$2*n$
match (8, true)
with
|
(0, )
-> 0
|
(n,false)
-> -n
|
(n, )
-> $2*n$
match (8, true)
with
|
(n,false)
-> -n
|
(n, )
$2*n$
match (8, true) with
| (n, )
-> $2*n$
02157 Functional Programming, Week 1
22 of 39

[Page 58]~
Example: Match on a pair
match $(3+5$,
$3<5.$
with
|
(0,
)
-> 0
|
(n,false)
-> -n
|
(n, )
-> $2*n$
match (8, true) with
| (0, )
-> 0
|
(n,false)
-> -n
|
(n, )
-> $2*n$
match (8, true) with
|
(n,false)
-> -n
|
(n,)
$2*n$
match (8, true) with
| (n, )
-> $2*n$
 $(2*n,n\mapsto8)\mapsto(16,n\mapsto8)$
02157 Functional Programming, Week 1
22 of 39

[Page 59]Evaluation. Example: power(4.0, 2)
let rec power(x,n) =
match (x,n) with
| $(_{-},0)->1.0$
| $(x,n)\rightarrow x*power(x,n-1)$
$power(4.0,2)$
$(*1*)$
(* 2 *)
[]
match (x,n) with
$[x\mapsto4.0,n\mapsto2]$
|
$(\_,0)\rightarrow1.0$
| $(x,n)\rightarrow x*power(x,n-1)$
match (4.0, 2) with
$[x\mapsto4.0,n\mapsto2]$
|
$(\_,0)\rightarrow1.0$
| $(x,n)\rightarrow x*power(x,n-1)$
match (4.0, 2) with
$[x\mapsto4.0,n\mapsto2]$
| $(x,n)\rightarrow x*power(x,n-1)$
  
←
$x*power(x,n-1)$
$[x\mapsto4.0,n\mapsto2]$
$4.0*power(4.0,1)$
$[x\mapsto4.0,n\mapsto2]$
Similarly:
$power(4.0,1)\sim4.0*power(4.0,0)$
$power(4.0,0)\sim1.0$
02157 Functional Programming, Week 1
23 of 39

[Page 60]Types
every expression has a type е: т
Basic types:

|  | type name   | example of values   |
| :--- | :--- | :--- |
| Integers  Floats   | int  float   | 27, 0, 15, 21000  27.3, 0.0, 48.21   |
| Booleans   | bool   | true, false   |

02157 Functional Programming, Week 1
24 of 39

[Page 61]Types
Basic types:

|  | type name   | example of values   |
| :--- | :--- | :--- |
| Integers   | int   | 27, 0, 15, 21000   |
| Floats   | float   | 27.3, 0.0, 48.21   |
| Booleans   | bool   | true, false   |

Pairs:
If e1: 71 and e2: T2
then $(e_{1},e_{2}):\tau_{1}*\tau_{2}$
every expression has a type е: т
pair (tuple) type constructor
02157 Functional Programming, Week 1
24 of 39

[Page 62]Types
every expression has a type е: т
Basic types:

|  | type name   | example of values   |
| :--- | :--- | :--- |
| Integers   | int   | 27, 0, 15, 21000   |
| Floats   | float   | 27.3, 0.0, 48.21   |
| Booleans   | bool   | true, false   |

Pairs:
If $e_{1}:\tau_{1}$ and $e_{2}:\tau_{2}$
then $(e_{1},e_{2}):\tau_{1}*\tau_{2}$
Functions:
if $f:\tau_{1}->\tau_{2}$ and $a:\tau_{1}$
then $f(a):\tau_{2}$
pair (tuple) type constructor
function type constructor
02157 Functional Programming, Week 1
24 of 39

[Page 63]Types
every expression has a type е: т
Basic types:

|  | type name   | example of values   |
| :--- | :--- | :--- |
| Integers   | int   | 27, 0, 15, 21000   |
| Floats   | float   | 27.3, 0.0, 48.21   |
| Booleans   | bool   | true, false   |

Pairs:
If $e_{1}:\tau_{1}$ and $e_{2}:\tau_{2}$
then $(e_{1},e_{2}):\tau_{1}*\tau_{2}$
Functions:
if $f:\tau_{1}->\tau_{2}$ and $a:\tau_{1}$
then $f(a):\tau_{2}$
Examples:
(4.0,2): float*int
pair (tuple) type constructor
function type constructor
power: float*int -> float
power (4.0, 2):
float
* has higher precedence than ->
02157 Functional Programming, Week 1
24 of 39

[Page 64]Type inference: power
let rec power $(x,n)=$
match (x,n) with
| $(_{-},0)->1.0$
| $(x,n)->x*power(x,n-1)$
(*1*)
(* 2 *)
02157 Functional Programming, Week 1
25 of 39

[Page 65]Type inference: power
let rec power $(x,n)=$
match (x,n) with
| $(_{-},0)->1.0$
| $(x,n)\rightarrow x*power(x,n-1)$
(*1*)
(* 2 *)
• The type of power must have the form: $\tau_{1}*\tau_{2}->\tau_{3}$ , because argument is a
pair.
02157 Functional Programming, Week 1
25 of 39

[Page 66]Type inference: power
let rec power $(x,n)=$
match (x,n) with
| $(_{-},0)->1.0$
(*1*)
| $(x,n)\rightarrow x*power(x,n-1)$
(* 2 *)
• The type of power must have the form: $\tau_{1}*\tau_{2}->\tau_{3}$
pair.
, because argument is a
• $\tau_{3}=$ float because 1.0:float
(Clause 1, function value.)
02157 Functional Programming, Week 1
25 of 39

[Page 67]Type inference: power
let rec power $(x,n)=$
match (x,n) with
| $(_{-},0)->1.0$
(*1*)
| $(x,n)->x*power(x,n-1)$
(* 2 *)
• The type of power must have the form: $\tau_{1}*\tau_{2}->\tau_{3}$
, because argument is a
pair.
•
$\tau_{3}=$ float because 1.0:float
(Clause 1, function value.)
•
$\tau_{2}=$
int because 0: int
(Clause 1, pattern in position for n).
02157 Functional Programming, Week 1
25 of 39

[Page 68]Type inference: power
let rec power $(x,n)=$
match (x,n) with
| $(_{-},0)->1.0$
(*1*)
| $(x,n)->x*power(x,n-1)$
(* 2 *)
• The type of power must have the form: $\tau_{1}*\tau_{2}->\tau_{3}$
pair.
• $\tau_{3}=$ float because 1.0:float
(Clause 1, pattern in position for n).
•
$\tau_{2}=$ int because 0: int
 x*power(x, n-1): float, because $\tau_{3}=$
float.
, because argument is a
(Clause 1, function value.)
02157 Functional Programming, Week 1
25 of 39

[Page 69]Type inference: power
let rec power $(x,n)=$
match (x,n) with
| $(_{-},0)->1.0$
| $(x,n)->x*power(x,n-1)$
(*1*)
(* 2 *)
, because argument is a
• $\tau_{3}=$ float because 1.0:float
• The type of power must have the form: $\tau_{1}*\tau_{2}->\tau_{3}$
pair.
(Clause 1, function value.)
•
$\tau_{2}=$ int because 0: int
(Clause 1, pattern in position for n).
• x*power(x,n-1): float, because $\tau_{3}=$ float.
• multiplication can have
int*int -> int or float*float -> float
as types, but no "mixture" of int and float
02157 Functional Programming, Week 1
25 of 39

[Page 70]Type inference: power
let rec power $(x,n)=$
match (x,n) with
| $(_{-},0)->1.0$
| $(x,n)\rightarrow x*power(x,n-1)$
(*1*)
(* 2 *)
, because argument is a
• The type of power must have the form: $\tau_{1}*\tau_{2}->\tau_{3}$
pair.
(Clause 1, function value.)
(Clause 1, pattern in position for n).
• $\tau_{3}=$ float because 1.0:float
•
$\tau_{2}=$ int because 0: int
• x*power(x,n-1): float, because $\tau_{3}=$
float.
• multiplication can have
int*int -> int or float*float -> float
as types, but no "mixture" of int and float
• Therefore x: float and $\tau_{1}=$ float.
02157 Functional Programming, Week 1
25 of 39

[Page 71]Type inference: power
let rec power $(x,n)=$
match (x,n) with
| $(_{-},0)->1.0$
| $(x,n)->x*power(x,n-1)$
(*1*)
(* 2 *)
, because argument is a
• $\tau_{3}=$ float because 1.0:float
• The type of power must have the form: $\tau_{1}*\tau_{2}->\tau_{3}$
pair.
(Clause 1, function value.)
•
$\tau_{2}=$ int because 0: int
(Clause 1, pattern in position for n).
• x*power(x,n-1): float, because $\tau_{3}=$ float.
• multiplication can have
int*int -> int or float*float -> float
as types, but no "mixture" of int and float
• Therefore x: float and $\tau_{1}=$ float.
The F# system determines the type float*int -> float
02157 Functional Programming, Week 1
25 of 39

[Page 72]Type inference: power
let rec power $(x,n)=$
match (x,n) with
| $(_{-},0)->1.0$
(*1*)
| (x,n) -> x * power(x,n-1)
(* 2 *)
• The type of power must have the form: $\tau_{1}*\tau_{2}->\tau_{3}$
pair.
, because argument is a
• $\tau_{3}=$ float because 1.0:float
(Clause 1, function value.)
•
$\tau_{2}=$ int because 0: int
(Clause 1, pattern in position for n).
• x*power(x,n-1): float, because $\tau_{3}=$
float.
• multiplication can have
int*int -> int or float*float -> float
as types, but no "mixture" of int and float
• Therefore x: float and $\tau_{1}=$ float.
The F# system determines the type float*int -> float
Note that this type works with the entire expression,
e.g. $n-1$ is of type int $=\tau_{2}$.
02157 Functional Programming, Week 1
25 of 39

[Page 73]A higher-order version of the power function
We shall now look at a version of power xn= with the type
power: float - (int -> float)
02157 Functional Programming, Week 1
26 of 39

[Page 74]A higher-order version of the power function
We shall now look at a version of power xn = with the type
power: float - (int -> float)
 the argument of power is the base x
02157 Functional Programming, Week 1
26 of 39

[Page 75]A higher-order version of the power function
We shall now look at a version of power xn = with the type
power: float - (int -> float)
• the argument of power is the base x
 and power x is the function that maps exponent n to $x^{n}$
02157 Functional Programming, Week 1
26 of 39

[Page 76]A higher-order version of the power function
We shall now look at a version of power $x~n=x^{n}$ with the type
power: float - (int -> float)
 the argument of power is the base x
 and power x is the function that maps exponent n to x"
The function may be evaluated in stages:
let pow2 = power 2.0;;
pow2 3;;
val it: float $=8.0$
pow2 4;;
val it: float $=16.0$
n
02157 Functional Programming, Week 1
26 of 39

[Page 77]A higher-order version of the power function
We shall now look at a version of power $x~n=x^{n}$ with the type
power: float - (int -> float)
• the argument of power is the base x
 and power x is the function that maps exponent n to x
The function may be evaluated in stages:
let pow2 = power 2.0;;
pow2 3;;
val it: float $=8.0$
pow2 4;;
val it: float = 16.0
This higher-order version of power is declared by
let rec power $\times n=$ match n with
| $0->1.0$
-> x * power x (n-1);;
n
02157 Functional Programming, Week 1
26 of 39

[Page 78]A higher-order version of the power function
We shall now look at a version of power $x~n=x^{n}$ with the type
power: float - (int -> float)
• the argument of power is the base x
 and power x is the function that maps exponent n to x"
The function may be evaluated in stages:
let pow2 = power 2.0;;
pow2 3;;
n
val it: $float=8.0$
pow2 4;;
val it: $float=16.0$
This higher-order version of power is declared by
let rec power $\times n=$ match n with
| $0->1.0$
-> x * power x (n-1);;
The value of the function is a function
02157 Functional Programming, Week 1
26 of 39

[Page 79]Expression
An expression for anonymous functions
An expression can also be an anonymous function:
function
 $pat_{1}\rightarrow e_{1}$
 $pat_{n}\rightarrow e_{n}$
This allows you to "tabulate" argument-value pairs of a function, e.g.:
function
| $2\rightarrow28$ // February
14 $4->30$ // April
| $6->30$ // June
19 $9->30$ // September
$11->30$
// November
-> 31;; // All other months
val it: int -> int = <fun:clo@17-2>
02157 Functional Programming, Week 1
27 of 39

[Page 80]Expression
An expression for anonymous functions
An expression can also be an anonymous function:
function
 $pat_{1}\rightarrow e_{1}$
:
 $pat_{n}\rightarrow e_{n}$
This allows you to "tabulate" argument-value pairs of a function, e.g.:
function
| $2\rightarrow28$ // February
14 $4->30$ // April
| $6->30$ // June
19 $9->30$ // September
| $11->30$
// November
-> 31;; // All other months
val it: int -> int
it 2;;
val it: $int=28$
02157 Functional Programming, Week 1
= <fun:clo@17-2>
27 of 39

[Page 81]Another higher-order version of the power function
We now have another look at power $x~n=x^{n}$ with the type
(int -> float)
power: float
02157 Functional Programming, Week 1
28 of 39

[Page 82]Another higher-order version of the power function
We now have another look at power $x~n=x^{n}$ with the type
power: float (int -> float)
The following declaration explicitly reveals that power x is a function:
let rec power $x=$
function
 $0->1.0$
$\begin{matrix}n&->&x&power&x&(n-1)\end{matrix}$ ;;
02157 Functional Programming, Week 1
28 of 39

[Page 83]Booleans
Type name bool
Values false, true

| Operator   | Type   |  |  |
| :--- | :--- | :--- | :--- |
| not   | bool ->   | bool   | negation   |

not true = false
not false = true
02157 Functional Programming, Week 1
29 of 39

[Page 84]Booleans
Type name bool
Values false, true

| Operator   | Type   |  |  |
| :--- | :--- | :--- | :--- |
| not   | bool ->   | bool   | negation   |

not true = false
not false = true
Expressions
02157 Functional Programming, Week 1
$e_{1}$ && $e_{2}$
$e_{1}$ || $e_{2}$
"conjunction $e_{1}\wedge{e_{2}}^{\prime\prime}$
"disjunction $e_{1}\vee{e_{2}}^{\prime\prime}$
29 of 39

[Page 85]Booleans
Type name bool
Values false, true

| Operator   | Type   |  |  |
| :--- | :--- | :--- | :--- |
| not   | bool ->   | bool   | negation   |

not true = false
not false = true
Expressions
$e_{1}$ && $e_{2}$
$e_{1}$ || $e_{2}$
"conjunction $\epsilon_{1}\wedge{e_{2}}^{\prime\prime}$
"disjunction $e_{1}\vee e_{2}"$
are lazily evaluated, e.g.
1<2 || $5/0=1$
→ true
Precedence: && has higher than ||
02157 Functional Programming, Week 1
29 of 39

[Page 86]Summary
• The interactive environment
• Values, expressions, types, patterns
• Declarations of values and recursive functions
• Binding, environment and evaluation
• Type inference
• higher-order functions
02157 Functional Programming, Week 1
30 of 39

[Page 87]Part 4 - Introduction to Lists
• Lists: values and constructors
• Recursions following the structure of lists
• Polymorphism
• The list concept is a natural, built-in ingredient of functional languages
02157 Functional Programming, Week 1
31 of 39

[Page 88]Lists
A list is a finite sequence of elements having the same type:
$[v_{1};...;v_{n}]$ ([] is called the empty list)
02157 Functional Programming, Week 1
32 of 39

[Page 89]Lists
A list is a finite sequence of elements having the same type:
$[v_{1};...;v_{n}]$ ([] is called the empty list)
[2;3;6];;
val it: int $list=[\begin{matrix}2;3;6\end{matrix}]$
02157 Functional Programming, Week 1
32 of 39

[Page 90]Lists
A list is a finite sequence of elements having the same type:
$[v_{1};...;v_{n}]$ ([] is called the empty list)
[2;3;6];;
val it: int list = [2; 3; 6]
["a"; "ab"; "abc"; ""];;
val it: string list = ["a"; "ab"; "abc"; ""]
02157 Functional Programming, Week 1
32 of 39

[Page 91]Lists
A list is a finite sequence of elements having the same type:
$[v_{1};...;v_{n}]$ ([] is called the empty list)
[2;3;6];;
val it: int list = [2; 3; 6]
["a"; "ab"; "abc"; ""];;
val it : string list = ["a"; "ab"; "abc"; ""]
[sin; cos];;
val it: (float->float) list = [<fun:...>; <fun:...>]
02157 Functional Programming, Week 1
32 of 39

[Page 92]Lists
A list is a finite sequence of elements having the same type:
$[v_{1};...;v_{n}]$ ([] is called the empty list)
[2;3;6];;
val it: int list = [2; 3; 6]
["a"; "ab"; "abc"; ""];;
val it : string list $=5^{\prime\prime}a^{\prime\prime}$ ; "ab"; "abc"; ""]
[sin; cos];;
val it: (float->float) list = [<fun:...>; $<fun:...>J$
[(1,true); (3,true));;
val it: $(int*bool)$ list = [(1, true); (3, true)]
02157 Functional Programming, Week 1
32 of 39

[Page 93]Lists
A list is a finite sequence of elements having the same type:
$[v_{1};...;v_{n}]$ ([] is called the empty list)
[2;3;6];;
val it: int list = [2; 3; 6]
["a"; "ab"; "abc"; ""];;
val it : string list $=5^{\prime\prime}a^{\prime\prime}$ ; "ab"; "abc"; ""]
[sin; cos];;
val it: (float->float) list
[(1,true); (3,true)];;
val it:
(int * bool) list =
[[]; [1]; [1;2]];;
= [<fun:...>; <fun:...>]
[(1, true); (3, true)]
val it: int list list = [[]; [1]; [1; 2]]
02157 Functional Programming, Week 1
32 of 39

[Page 94]The formal definition of lists:
Definition
List constructors
Lists can be constructed as follows:
• [ (the empty list)
• If x is a value and  is a list, then also
is a list.
x::/
02157 Functional Programming, Week 1
33 of 39

[Page 95]The formal definition of lists:
Definition
List constructors
Lists of type  can be constructed as follows:
• [ (the empty list)
• If x is a value of type  and  is a T list, then also
is a
list.
02157 Functional Programming, Week 1
x::/
33 of 39

[Page 96]The formal definition of lists:
Definition
List constructors
Lists of type  can be constructed as follows:
• [ (the empty list)
• If x is a value of type  and  is a  list, then also
x::/
is a list.
The notation $[x_{1};x_{2};...;x_{n}]$ is just a shorthand for X₁::X2::::::[].
02157 Functional Programming, Week 1
33 of 39

[Page 97]The formal definition of lists:
Definition
List constructors
Lists of type  can be constructed as follows:
• [ (the empty list)
• If x is a value of type  and  is a  list, then also
is a list.
x::1
The notation $[x_{1};x_{2};...;x_{n}]$ is just a shorthand for X1::X2::::::[].
The constructor :: is called cons
02157 Functional Programming, Week 1
33 of 39

[Page 98]The formal definition of lists:
Definition
List constructors
Lists of type  can be constructed as follows:
• [ (the empty list)
• If x is a value of type  and  is a  list, then also
is a list.
x::/
The notation $[x_{1};x_{2};...;x_{n}]$ is just a shorthand for $X_{1\cdot\cdot\cdot}X_{2\cdot\cdot\cdot\cdot\cdot\cdot\cdot\cdot\cdot\cdot\cdot\cdot\cdot X_{n\cdot\cdot\cdot}^{\cdot\cdot\cdot}$.
The constructor :: is called cons
For a non-empty list $[x_{1};x_{2};...;x_{n}]$, $n\ge1$, we call
$x_{1}$
the head and
• $[x_{2};...;x_{n}]$ the tail.
There are library functions List.head and List.tail.
02157 Functional Programming, Week 1
33 of 39

[Page 99]Recursion on lists a simple example
$suml[x_{1};x_{2};...;x_{n}]=\sum_{i=1}^{n}x_{i}=x_{1}+x_{2}+\cdot\cdot\cdot+x_{n}=x_{1}+\sum_{i=2}^{n}x_{i}$
02157 Functional Programming, Week 1
34 of 39

[Page 100]Recursion on lists a simple example
$uml[x_{1};x_{2};...;x_{n}]=\sum_{i=1}^{n}x_{i}=x_{1}+x_{2}+\cdot\cdot\cdot+x_{n}=x_{1}+\sum_{i=2}^{n}x_{i}$
let rec suml xs =
match xs with
|
[]
-> 0
| x::tail -> x + suml tail;;
val suml: int list -> int
02157 Functional Programming, Week 1
Constructors are used in list patterns
34 of 39

[Page 101]Recursion on lists – a simple example
suml [x1;x2; . . . ;xn] =
Xn
i=1
xi = x1 + x2 + · · · + xn = x1 +
Xn
i=2
xi
Constructors are used in list patterns
let rec suml xs =
match xs with
| [] -> 0
| x::tail -> x + suml tail;;
val suml : int list -> int
suml [1;2]
⇝ 1 + suml [2] (x 7→ 1 and tail 7→ [2])
⇝ 1 + (2 + suml []) (x 7→ 2 and tail 7→ [])
⇝ 1 + (2 + 0) (the pattern [] matches the value [])
⇝ 1 + 2
⇝ 3
Recursion follows the structure of lists
02157 Functional Programming, Week 1 34 of 39 

[Page 102]A polymorphic list function (I)
The function remove y xs gives the list obtained from xs by deleting every
occurrence of y, e.g. remove 2 [1; 2; 0; 2; 7] = [1; 0; 7].
Recursion is following the structure of the list:
let rec remove y xs =
match xs with
| [] -> []
| x::tail when x=y -> remove y tail
| x::tail -> x::remove y tail;;
List elements can be of any type that supports equality
remove : ’a -> ’a list -> ’a list when’a : equality
• ’a is a type variable
• ’a : equality is a type constraint
The F# system infers the most general type for remove
02157 Functional Programming, Week 1 35 of 39 

[Page 103]A polymorphic list function (I)
The function remove y xs gives the list obtained from xs by deleting every
occurrence of y, e.g. remove 2 [1; 2; 0; 2; 7] = [1; 0; 7].
Recursion is following the structure of the list:
let rec remove y xs =
match xs with
| [] -> []
| x::tail when x=y -> remove y tail
| x::tail -> x::remove y tail;;
List elements can be of any type that supports equality
remove : ’a -> ’a list -> ’a list when’a : equality
• ’a is a type variable
• ’a : equality is a type constraint
The F# system infers the most general type for remove
02157 Functional Programming, Week 1 35 of 39 

[Page 104]A polymorphic list function (I)
The function remove y xs gives the list obtained from xs by deleting every
occurrence of y, e.g. remove 2 [1; 2; 0; 2; 7] = [1; 0; 7].
Recursion is following the structure of the list:
let rec remove y xs =
match xs with
| [] -> []
| x::tail when x=y -> remove y tail
| x::tail -> x::remove y tail;;
List elements can be of any type that supports equality
remove : ’a -> ’a list -> ’a list when’a : equality
• ’a is a type variable
• ’a : equality is a type constraint
The F# system infers the most general type for remove
02157 Functional Programming, Week 1 35 of 39 

[Page 105]A polymorphic list function (I)
The function remove y xs gives the list obtained from xs by deleting every
occurrence of y, e.g. remove 2 [1; 2; 0; 2; 7] = [1; 0; 7].
Recursion is following the structure of the list:
let rec remove y xs =
match xs with
| [] -> []
| x::tail when x=y -> remove y tail
| x::tail -> x::remove y tail;;
List elements can be of any type that supports equality
remove : ’a -> ’a list -> ’a list when’a : equality
• ’a is a type variable
• ’a : equality is a type constraint
The F# system infers the most general type for remove
02157 Functional Programming, Week 1 35 of 39 

[Page 106]A polymorphic list function (II)
• A type containing type variables is called a polymorphic type
• The remove function is called a polymorphic function.
remove : ’a -> ’a list -> ’a list when ’a : equality
The function has many forms, one for each instantiation of ’a:
Instantiating ’a with int:
remove 2 [1; 2; 0; 2; 7];;
val it : int list = [1; 0; 7]
Instantiating ’a with int list:
remove [2] [[2;1]; [2]; [0;1]; [2]; [5;6;7]];;
val it : int list list = [[2; 1]; [0; 1]; [5; 6; 7]]
Notice that -> associates to the right:
’a -> ’a list -> ’a list means ’a -> (’a list -> ’a list)
02157 Functional Programming, Week 1 36 of 39 

[Page 107]A polymorphic list function (II)
• A type containing type variables is called a polymorphic type
• The remove function is called a polymorphic function.
remove : ’a -> ’a list -> ’a list when ’a : equality
The function has many forms, one for each instantiation of ’a:
Instantiating ’a with int:
remove 2 [1; 2; 0; 2; 7];;
val it : int list = [1; 0; 7]
Instantiating ’a with int list:
remove [2] [[2;1]; [2]; [0;1]; [2]; [5;6;7]];;
val it : int list list = [[2; 1]; [0; 1]; [5; 6; 7]]
Notice that -> associates to the right:
’a -> ’a list -> ’a list means ’a -> (’a list -> ’a list)
02157 Functional Programming, Week 1 36 of 39 

[Page 108]A polymorphic list function (II)
• A type containing type variables is called a polymorphic type
• The remove function is called a polymorphic function.
remove : ’a -> ’a list -> ’a list when ’a : equality
The function has many forms, one for each instantiation of ’a:
Instantiating ’a with int:
remove 2 [1; 2; 0; 2; 7];;
val it : int list = [1; 0; 7]
Instantiating ’a with int list:
remove [2] [[2;1]; [2]; [0;1]; [2]; [5;6;7]];;
val it : int list list = [[2; 1]; [0; 1]; [5; 6; 7]]
Notice that -> associates to the right:
’a -> ’a list -> ’a list means ’a -> (’a list -> ’a list)
02157 Functional Programming, Week 1 36 of 39 

[Page 109]A polymorphic list function (II)
• A type containing type variables is called a polymorphic type
• The remove function is called a polymorphic function.
remove : ’a -> ’a list -> ’a list when ’a : equality
The function has many forms, one for each instantiation of ’a:
Instantiating ’a with int:
remove 2 [1; 2; 0; 2; 7];;
val it : int list = [1; 0; 7]
Instantiating ’a with int list:
remove [2] [[2;1]; [2]; [0;1]; [2]; [5;6;7]];;
val it : int list list = [[2; 1]; [0; 1]; [5; 6; 7]]
Notice that -> associates to the right:
’a -> ’a list -> ’a list means ’a -> (’a list -> ’a list)
02157 Functional Programming, Week 1 36 of 39 

[Page 110]Exploiting structured patterns: the isPrefix function
The function isPrefix xs ys tests whether the list xs is a prefix of the list ys, for
example:
isPrefix [1; 2; 3] [1; 2; 3; 8; 9] = true
isPrefix [1; 2; 3] [1; 2; 8; 3; 9] = false
The function is declared as follows:
let rec isPrefix xs ys =
match (xs,ys) with
| ([],_) -> true
| (_,[]) -> false
| (x::xtail,y::ytail) -> x=y && isPrefix xtail ytail;;
isPrefix [1;2;3] [1;2];;
val it : bool = false
A each clause expresses succinctly a natural property:
• The empty list is a prefix of any list
• A non-empty list is not a prefix of the empty list
• A non-empty list (...) is a prefix of another non-empty list (...) if ...
02157 Functional Programming, Week 1 37 of 39 

[Page 111]Exploiting structured patterns: the isPrefix function
The function isPrefix xs ys tests whether the list xs is a prefix of the list ys, for
example:
isPrefix [1; 2; 3] [1; 2; 3; 8; 9] = true
isPrefix [1; 2; 3] [1; 2; 8; 3; 9] = false
The function is declared as follows:
let rec isPrefix xs ys =
match (xs,ys) with
| ([],_) -> true
| (_,[]) -> false
| (x::xtail,y::ytail) -> x=y && isPrefix xtail ytail;;
isPrefix [1;2;3] [1;2];;
val it : bool = false
A each clause expresses succinctly a natural property:
• The empty list is a prefix of any list
• A non-empty list is not a prefix of the empty list
• A non-empty list (...) is a prefix of another non-empty list (...) if ...
02157 Functional Programming, Week 1 37 of 39 

[Page 112]Exploiting structured patterns: the isPrefix function
The function isPrefix xs ys tests whether the list xs is a prefix of the list ys, for
example:
isPrefix [1; 2; 3] [1; 2; 3; 8; 9] = true
isPrefix [1; 2; 3] [1; 2; 8; 3; 9] = false
The function is declared as follows:
let rec isPrefix xs ys =
match (xs,ys) with
| ([],_) -> true
| (_,[]) -> false
| (x::xtail,y::ytail) -> x=y && isPrefix xtail ytail;;
isPrefix [1;2;3] [1;2];;
val it : bool = false
A each clause expresses succinctly a natural property:
• The empty list is a prefix of any list
• A non-empty list is not a prefix of the empty list
• A non-empty list (...) is a prefix of another non-empty list (...) if ...
02157 Functional Programming, Week 1 37 of 39 

[Page 113]Exploiting structured patterns: the isPrefix function
The function isPrefix xs ys tests whether the list xs is a prefix of the list ys, for
example:
isPrefix [1; 2; 3] [1; 2; 3; 8; 9] = true
isPrefix [1; 2; 3] [1; 2; 8; 3; 9] = false
The function is declared as follows:
let rec isPrefix xs ys =
match (xs,ys) with
| ([],_) -> true
| (_,[]) -> false
| (x::xtail,y::ytail) -> x=y && isPrefix xtail ytail;;
isPrefix [1;2;3] [1;2];;
val it : bool = false
A each clause expresses succinctly a natural property:
• The empty list is a prefix of any list
• A non-empty list is not a prefix of the empty list
• A non-empty list (...) is a prefix of another non-empty list (...) if ...
02157 Functional Programming, Week 1 37 of 39 

[Page 114]Exploiting structured patterns: the isPrefix function
The function isPrefix xs ys tests whether the list xs is a prefix of the list ys, for
example:
isPrefix [1; 2; 3] [1; 2; 3; 8; 9] = true
isPrefix [1; 2; 3] [1; 2; 8; 3; 9] = false
The function is declared as follows:
let rec isPrefix xs ys =
match (xs,ys) with
| ([],_) -> true
| (_,[]) -> false
| (x::xtail,y::ytail) -> x=y && isPrefix xtail ytail;;
isPrefix [1;2;3] [1;2];;
val it : bool = false
A each clause expresses succinctly a natural property:
• The empty list is a prefix of any list
• A non-empty list is not a prefix of the empty list
• A non-empty list (...) is a prefix of another non-empty list (...) if ...
02157 Functional Programming, Week 1 37 of 39 

[Page 115]Exploiting structured patterns: the isPrefix function
The function isPrefix xs ys tests whether the list xs is a prefix of the list ys, for
example:
isPrefix [1; 2; 3] [1; 2; 3; 8; 9] = true
isPrefix [1; 2; 3] [1; 2; 8; 3; 9] = false
The function is declared as follows:
let rec isPrefix xs ys =
match (xs,ys) with
| ([],_) -> true
| (_,[]) -> false
| (x::xtail,y::ytail) -> x=y && isPrefix xtail ytail;;
isPrefix [1;2;3] [1;2];;
val it : bool = false
A each clause expresses succinctly a natural property:
• The empty list is a prefix of any list
• A non-empty list is not a prefix of the empty list
• A non-empty list (...) is a prefix of another non-empty list (...) if ...
02157 Functional Programming, Week 1 37 of 39 

[Page 116]Summary
• Lists
• Polymorphism
• Constructors (:: and [] for lists)
• Patterns
• Recursion on the structure of lists
• Constructors used in patterns to decompose structured values
• Constructors used in expressions to compose structured values
02157 Functional Programming, Week 1 38 of 39 

[Page 117]Summary
• Lists
• Polymorphism
• Constructors (:: and [] for lists)
• Patterns
• Recursion on the structure of lists
• Constructors used in patterns to decompose structured values
• Constructors used in expressions to compose structured values
02157 Functional Programming, Week 1 38 of 39 

[Page 118]Summary
• Lists
• Polymorphism
• Constructors (:: and [] for lists)
• Patterns
• Recursion on the structure of lists
• Constructors used in patterns to decompose structured values
• Constructors used in expressions to compose structured values
02157 Functional Programming, Week 1 38 of 39 

[Page 119]Summary
• Lists
• Polymorphism
• Constructors (:: and [] for lists)
• Patterns
• Recursion on the structure of lists
• Constructors used in patterns to decompose structured values
• Constructors used in expressions to compose structured values
02157 Functional Programming, Week 1 38 of 39 

[Page 120]Summary
• Lists
• Polymorphism
• Constructors (:: and [] for lists)
• Patterns
• Recursion on the structure of lists
• Constructors used in patterns to decompose structured values
• Constructors used in expressions to compose structured values
02157 Functional Programming, Week 1 38 of 39 

[Page 121]Summary
• Lists
• Polymorphism
• Constructors (:: and [] for lists)
• Patterns
• Recursion on the structure of lists
• Constructors used in patterns to decompose structured values
• Constructors used in expressions to compose structured values
02157 Functional Programming, Week 1 38 of 39 

[Page 122]Summary
• Lists
• Polymorphism
• Constructors (:: and [] for lists)
• Patterns
• Recursion on the structure of lists
• Constructors used in patterns to decompose structured values
• Constructors used in expressions to compose structured values
02157 Functional Programming, Week 1 38 of 39 

[Page 123]Summary
• Lists
• Polymorphism
• Constructors (:: and [] for lists)
• Patterns
• Recursion on the structure of lists
• Constructors used in patterns to decompose structured values
• Constructors used in expressions to compose structured values
02157 Functional Programming, Week 1 38 of 39 

[Page 124]Exercises
Installation:
• Try to get a working installation and run the power example from the lecture.
Recursive Functions:
• Hansen and Rischel Book (HR):
Exercise 1.4: Define a function f with $f (n) = 1 + 2 + . . . + n$.
Exercise 1.6: Define a function sum such that
$sum(m, n) = m + (m + 1) + ... + (m + n - 1) + (m + n)$
Exercise 2.8: Define $\binom{n}{k}$ where $0 \le k \le n$, according to the definition:
$\binom{n}{0} = \binom{n}{n} = 1$
$\binom{n}{k} = \binom{n-1}{k} + \binom{n-1}{k-1}$
Lists:
• memberOf x ys is true iff x occurs in the list ys
• insert(x, ys) where ys is an ordered list, insert x into the list such that the
resulting list is also ordered.
• sort(xs) gives a ordered version of xs
⋆ Implement sort using insert.
⋆ Expert question (if you have time): what is the worst-case number of steps of
this algorithm? How can this be made more efficient?
02157 Functional Programming, Week 1 39 of 39