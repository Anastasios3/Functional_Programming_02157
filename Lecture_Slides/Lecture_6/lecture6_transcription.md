# 02157 Functional Programming, Week 6: Lambda Calculus

Transcribed from `Lecture6-lambda.pdf`, 24 slides, one section per slide.

## Slide 1 of 24

**02157 Functional Programming**

**Week 6:**

**Lambda Calculus**

Sebastian Mödersheim

October 9, 2026

## Slide 2 of 24: Introduction

Today we look at the theoretical foundations of functional programming:

***The Lambda Calculus***

* Developed by Church, Turing, Rosser in the late 1930s
* Succinct and elegant way to think about computation
  * Very small syntax
  * Semantics is just one rule ... but there is a lot to say about it
* Basis for all functional languages
* All of F# can be just seen as *syntactic sugar* (abbreviating notation) for Lambda Calculus.

Since this all advanced and rooted in mathematical logic,

***I will not ask about Lambda Calculus in the exam.***

*Please do not ignore the topic, it gives a deeper understanding!*

## Slide 3 of 24: Outline

1. **Syntax**
2. Semantics
3. Termination
4. Syntactic Sugar

## Slide 4 of 24: Lambda Calculus: Syntax

### Lambda Calculus

Given a set of variables (i.e., identifiers), the set of *expressions* is defined as follows.

* If $x$ is a variable then $\boxed{x}$ is an expression.
* If $e$ is an expression and $x$ is a variable, then also $\boxed{\lambda x.e}$ is an expression.
* If $e$ and $e'$ are expressions, then also $\boxed{e\ e'}$ is an expression.
* If $e$ is an expression, then also $\boxed{(e)}$ is an expression.

Written as a context-free grammar: $\mathit{expr} ::= \mathit{var} \mid \lambda\mathit{var}.\mathit{expr} \mid \mathit{expr}\ \mathit{expr} \mid (\mathit{expr})$

Thus we only have:

* Variables
* Function defintion aka *Lambda-Abstraction $\lambda x.e$*
  * corresponds to `fun x->e` in F#.

    (and everything else means literally the same as in F#.)
* Function Application
* Parentheses for structuring larger expressions

This is obviously the *bare minumum* for expressing functions

*... and we now show it is sufficient to express all computable functions.*

## Slide 5 of 24: What can we do?

$$
\mathit{expr} ::= \mathit{var} \mid \lambda\mathit{var}.\mathit{expr} \mid \mathit{expr}\ \mathit{expr} \mid (\mathit{expr})
$$

This gives us almost nothing:

* There are no builtin datatypes like `int`
* There are no builtin functions like $+, \star$
* We cannot use recursion
  * because you cannot recursively call a function if it is anonymous
* How can we really do *anything* in this *Pure* Lambda Calculus??

Answer:

* Syntactic sugar: One can encode everything, and we see that soon
  * theoretically appealing because we need only a very small language to describe a Turing-complete programming language
* Applied Lambda calculus: include primitive data types and operations
  * more efficient than theoretical encodings
  * for the sake of examples we will assume for now that we have integers and operators already

## Slide 6 of 24: Outline

1. Syntax
2. **Semantics**
3. Termination
4. Syntactic Sugar

## Slide 7 of 24: Evaluation of Lambda Expressions

Let us look at an example how we would expect Lambda expressions to *evaluate*:

### Example

$$
\begin{aligned}
&(\lambda x.x \ast x)\ (2 + 5) \\
&\to (\lambda x.x \ast x)\ 7 \\
&\to 7 \ast 7 \to 49
\end{aligned}
$$

### Example

$$
\begin{aligned}
&(\lambda f.\lambda g.\lambda x.f\ (g\ x))\ (\lambda a.a + 2)\ (\lambda b.b \ast b)\ 3 \\
&\to (\lambda g.\lambda x.(\lambda a.a + 2)\ (g\ x))\ (\lambda b.b \ast b)\ 3 \\
&\to (\lambda x.(\lambda a.a + 2)\ ((\lambda b.b \ast b)\ x))\ 3 \\
&\to (\lambda a.a + 2)\ ((\lambda b.b \ast b)\ 3) \\
&\to (\lambda a.a + 2)\ (3 \ast 3) \\
&\to (\lambda a.a + 2)\ 9 \\
&\to 9 + 2 \to 11
\end{aligned}
$$

How can we make this precise? That’s the *semantics*.

## Slide 8 of 24: Semantics: $\beta$-Reduction

We have just used a *relation* $\to$ to mean *evaluating expressions*. Formal definition

### Definition ($\beta$-Reduction)

A term of the form $(\lambda x.e)\ e'$ is called a *$\beta$-redex*.

A *$\beta$-reduction* is of the form

$$
(\lambda x.e)\ e' \to e[x \mapsto e']
$$

where $e[x \mapsto e']$ *roughly* means: take $e$ and replace every occurrence of $x$ by $e'$.

Example:

$$
\begin{aligned}
&(\lambda x.\lambda y.x + y)\ 7\ 3 \\
&\to (\lambda y.x + y)[x \mapsto 7]\ 3 = (\lambda y.7 + y)\ 3 \\
&\to (7 + y)[y \mapsto 3] = 7 + 3 = 10
\end{aligned}
$$

Why *roughly*?

* We must be careful not to capture *free* variables e.g.,

  $(\lambda x.\lambda y.x + y)\ y \not\to \lambda y.y + y$
* In such a case an *$\alpha$-renaming* is necessary, renaming the bound variable $y$ to something else:

  $(\lambda x.\lambda y.x + y)\ y \equiv (\lambda x.\lambda z.x + z)\ y \to \lambda z.y + z$

## Slide 9 of 24: Semantics: Normal Form

### Definition (Normal-Form)

An expression $e$ is in *normal form*, if no subterm of $e$ is a $\beta$-redex.

Example:

$$
\begin{aligned}
&(\lambda x.\lambda y.x + y)\ 7\ 3 \\
&\to (\lambda y.x + y)[x \mapsto 7]\ 3 = (\lambda y.7 + y)\ 3 \\
&\to (7 + y)[y \mapsto 3] = 7 + 3 = 10 \quad \textit{is in normal form}
\end{aligned}
$$

### Theorem (Church-Rosser)

*$\beta$-reduction is confluent (modulo $\alpha$ renaming $\equiv$), i.e.,*

* *if $e \to^{\ast} e_1$ and $e \to^{\ast} e_2$*
* *and $e_1$ and $e_2$ are in normal form,*
* *then $e_1 \equiv e_2$*

Example (assuming we already have arithmetic):

consider all the reductions of $(\lambda x.x \star x)(3 + 5)$:

$$
\begin{aligned}
&(\lambda x.x \star x)\ (3 + 5) \to (3 + 5) \star (3 + 5) \to 8 \star (3 + 5) \to 8 \star 8 \to 64 \\
&(\lambda x.x \star x)\ (3 + 5) \to (3 + 5) \star (3 + 5) \to (3 + 5) \star 8 \to 8 \star 8 \to 64 \\
&(\lambda x.x \star x)\ (3 + 5) \to (\lambda x.x \star x)\ 8 \to 8 \star 8 \to 64
\end{aligned}
$$

## Slide 10 of 24: Semantics: Evaluation Strategy

* Evaluation strategy: which reduction is performed first.
* Confluence means that the result does not depend on the evaluation strategy.
* However, whether evaluation terminates can depend on the evaluation strategy.
* This is a complicated issue that we deal with in another lecture.
* For now we take the strategy *outermost-leftmost*:
  * The redex $(\lambda x.e_1)\ e_2 \to e_1[x \mapsto e_2]$ has priority over all redices in $e_1$ and $e_2$
  * In $e_1\ e_2$ we first normalize $e_1$ and then $e_2$.
* This strategy is optimal for termination
  * if there is a normal form, we will reach it with this strategy.

## Slide 11 of 24: Outline

1. Syntax
2. Semantics
3. **Termination**
4. Syntactic Sugar

## Slide 12 of 24: Semantics: Termination

Not every term has a normal form:

$\mathit{let}\ e_{\bot} = (\lambda x.x\ x)\ (\lambda x.x\ x)$

* This is a “strange” term: $x$ is both used as a function and as an argument to that function!
* This would not be allowed by the type system in F#
  * because $x : \alpha \to \beta$ and $x : \alpha$ is not possible at the same time.
* However, Pure Lambda Calculus is untyped; writing such strange terms is perfectly legal.
* It holds that:

$e_{\bot} = (\lambda x.x\ x)\ (\lambda x.x\ x) \to (x\ x)[x \mapsto (\lambda x.x\ x)] = (\lambda x.x\ x)\ (\lambda x.x\ x) = e_{\bot}$

* Thus, $e_{\bot} \to e_{\bot}$ and we never reach a normal form.
* Claim: in every reasonable programming language it must be possible to specify a program that loops forever.

  Of course, $e_{\bot}$ is not really useful – similar to `while(true){}` in C/Java.
* We see later that we can use something similar to $e_{\bot}$ for recursion!

## Slide 13 of 24: Semantics: The Semantics Function

We can now define the semantics, or meaning, of a lambda expression as its normal form, if it exists. Otherwise, its semantics is *$\bot$ (undefined)*.

### Definition

For a lambda expression $e$ its semantics $[\![e]\!]$ is either

* $e'$ if $e \to^{\star} e'$ and $e'$ in normal form,
* $\bot$ if there is no such $e'$.

Thus $[\![\cdot]\!]$ is a *partial* function from expressions to expressions.

Note that if normal form $e'$ exists, then it is unique (modulo $\alpha$-renaming).

Examples:

* $[\![(\lambda x.\lambda y.x)\ \mathit{true}\ \mathit{false}]\!] = \mathit{true}$
* $[\![(\lambda x.\lambda y.x)\ e_{\bot}\ \mathit{false}]\!] = \bot$ (undefined, does not terminate)
* $[\![(\lambda x.\lambda y.x)\ \mathit{true}\ e_{\bot}]\!] = \mathit{true}$

## Slide 14 of 24: The Halting Problem

*Reformulated for Lambda Calculus*

### Definition (The Halting Problem)

$$
\mathit{Halt}(e) = \begin{cases} \mathit{true} & \text{if } [\![e]\!] \neq \bot \\ \mathit{false} & \text{otherwise} \end{cases}
$$

### Theorem (Turing)

*$\mathit{Halt}$ is undecidable, i.e., there is no expression $H$ such that $[\![H\ e]\!] = \mathit{Halt}(e)$ for every expression $e$.*

### Proof.

Suppose there is an expression $H$ such that for every expression $e$, $[\![H\ e]\!] = \mathit{Halt}(e)$.

Consider the expression $\mathit{Test} = \lambda e.\mathit{if}\ H\ (e\ e)\ \mathit{then}\ e_{\bot}\ \mathit{else}\ \mathit{true}$

Then the following statements are equivalent:

* $\mathit{Halt}(\mathit{Test}\ \mathit{Test}) = \mathit{true}$
* $[\![\mathit{Test}\ \mathit{Test}]\!] \neq \bot$
* $[\![\mathit{if}\ H\ (\mathit{Test}\ \mathit{Test})\ \mathit{then}\ e_{\bot}\ \mathit{else}\ \mathit{true}]\!] \neq \bot$
* $[\![H\ (\mathit{Test}\ \mathit{Test})]\!] = \mathit{false}$
* $\mathit{Halt}(\mathit{Test}\ \mathit{Test}) = \mathit{false}$

q.e.a.

## Slide 15 of 24: Outline

1. Syntax
2. Semantics
3. Termination
4. **Syntactic Sugar**

## Slide 16 of 24: Pure Lambda Calculus

$$
\mathit{expr} ::= \mathit{var} \mid \lambda\mathit{var}.\mathit{expr} \mid \mathit{expr}\ \mathit{expr} \mid (\mathit{expr})
$$

We have before assumed that we have at least integers and arithmetic operations.

We want to now show that we can encode in *Pure Lambda Calculus*:

* Algebraic Data Types
  * and thus also ints, strings, lists, $\ldots$
* Recursion
  * and thus also addition, multiplication, list operations, $\ldots$

Notation:

* Similar to F#, let us write $\mathit{let}\ f = e$ to (non-recursively) define a function $f$ by the expression $e$.
* This means nothing but an abbreviation: we can use in the following the identifier $f$ instead of writing out expression $e$.
* Similar to F#, let us write $\mathit{let}\ f\ x_1\ x_2\ \ldots\ x_n = e$ for $\mathit{let}\ f = \lambda x_1.\lambda x_2. \cdots \lambda x_n.e$

## Slide 17 of 24: Example: Quantified Boolean Logic

Here is an idea how to encode a data type like boolean by *continuation-style programming*.

### Encoding of Quantified Boolean Logic

$$
\begin{array}{lcl}
\mathit{let}\ \mathit{true} & = & \lambda x.\lambda y.x \\
\mathit{let}\ \mathit{false} & = & \lambda x.\lambda y.y \\
\mathit{let}\ \mathit{not}\ b & = & \text{if}\ b\ \text{then}\ \mathit{false}\ \text{else}\ \mathit{true} \\
\mathit{let}\ \mathit{and}\ b_1\ b_2 & = & \text{if}\ b_1\ \text{then}\ b_2\ \text{else}\ \mathit{false} \\
\mathit{let}\ \mathit{or}\ b_1\ b_2 & = & \text{if}\ b_1\ \text{then}\ \mathit{true}\ \text{else}\ b_2 \\
\mathit{let}\ \mathit{exists}\ p & = & \mathit{or}\ (p\ \mathit{true})\ (p\ \mathit{false}) \\
\mathit{let}\ \mathit{forall}\ p & = & \mathit{and}\ (p\ \mathit{true})\ (p\ \mathit{false})
\end{array}
$$

Note: Consider the words if then else as pure commentary—they just makes it more intuitive to read.

Example: $\mathit{forall}\ (\lambda x.\mathit{or}\ x\ (\mathit{not}\ x)) =?$

## Slide 18 of 24: Encoding Arithmetic

| Algebraic Data Type | Encoding in $\lambda$-Calculus |
| --- | --- |
| $\mathit{type}\ \mathit{Bool} = \mathit{true}$ | $\mathit{let}\ \mathit{true} = \lambda x.\lambda y.x$ |
| $\mid \mathit{false}$ | $\mathit{let}\ \mathit{false} = \lambda x.\lambda y.y$ |
| $\mathit{type}\ \mathit{Nat} = 0$ | $\mathit{let}\ 0 = \lambda x.\lambda y.x$ |
| $\mid s\ \mathit{of}\ \mathit{Nat}$ | $\mathit{let}\ s\ n = \lambda x.\lambda y.y\ n$ |

* Idea: Booleans we had previously encoded as functions that take two *continuations* $x$ and $y$: $x$ for the case true and $y$ for the case false, and we call the respective continuation.
* For natural numbers, we can also take two continuations $x$ and $y$, $x$ for the case 0 and $y$ for the non-zero case:
  * $s\ n$ represents “successor of $n$” i.e. $n + 1$.
  * E.g. 3 is thus encoded as $s(s(s(0)))$. This is unary encoding, terrible for efficiency, but we get back to that.
* For number $s\ n$, the continuation $y$ gets $n$ as an argument. Why?
  * This allows in computations to further work with the predecessor $n$, e.g. in a recursion.

## Slide 19 of 24: Encoding Arithmetic

To work more easily with the continuations we can define *Pattern matching* as syntactic sugar:

$$
\boxed{\begin{array}{l}
\mathit{match}\ e\ \mathit{with} \\
\begin{array}{ll} \mid 0 & \to e_0 \\ \mid s\ n & \to e_s \end{array}
\end{array}}
\text{ as syntactic sugar for }
\boxed{e\ e_0\ (\lambda n.e_s)}
$$

Now we can define addition (and similarly multiplication and exponentiation):

$$
\begin{array}{l}
\mathit{let}\ \mathit{rec}\ \mathit{add}\ n\ m = \mathit{match}\ n\ \mathit{with} \\
\qquad \begin{array}{ll} \mid 0 & \to m \\ \mid s\ n' & \to s\ (\mathit{add}\ n'\ m) \end{array}
\end{array}
$$

$\ldots$ but this requires that we can somehow express recursion in Lambda Calculus.

## Slide 20 of 24: Recursion in Lambda Calculus

Remember $e_{\bot} = (\lambda x.x\ x)\ (\lambda x.x\ x)$ that creates a useless infinite loop.

But a similar construction can actually do something useful:

### Definition (Fixedpoint Combinator)

$$
\mathit{let}\ Y = \lambda F.\ (\lambda x.F\ (x\ x))\ (\lambda x.F\ (x\ x))
$$

## Slide 21 of 24: Recursion in Lambda Calculus

$$
Y\ F \to F(Y\ F)
$$

With that we can express recursion:

### Definition

$$
\begin{array}{l}
\mathit{let}\ \mathit{add0}\ f\ n\ m = \mathit{match}\ n\ \mathit{with} \\
\qquad \begin{array}{ll} \mid 0 & \to m \\ \mid s\ n' & \to s\ (f\ n'\ m) \end{array} \\
\mathit{let}\ \mathit{add} = Y\ \mathit{add0}
\end{array}
$$

Observe that there is no recursion in this definition.

## Slide 22 of 24: Similar Definitions

### Arithmetic

One can in similar recursive definitions define

* Multiplication, exponentiation, comparison, subtraction and division as far as defined on natural numbers.
* Because of the unary representation this is extremely inefficient, but we can encode natural numbers arithmetic.
* With that and recursion we are *Turing complete*.
* One can also make a asymptotically optimal implementation with a binary representation — i.e., a *lists of bools*.

## Slide 23 of 24: Encoding Lists

We use the same trick to encode algebraic data types:

### Encoding Lists

| Algebraic Data Type | Encoding in $\lambda$-Calculus |
| --- | --- |
| $\mathit{type}\ \alpha\ \mathit{List} = \mathit{Empty}$ | $\mathit{let}\ \mathit{Empty} = \lambda x.\lambda y.x$ |
| $\mid \mathit{Cons}\ \mathit{of}\ (\alpha, \alpha\ \mathit{List})$ | $\mathit{let}\ \mathit{Cons}\ a\ \mathit{as} = \lambda x.\lambda y.y\ a\ \mathit{as}$ |

$$
\boxed{\begin{array}{l}
\mathit{match}\ e\ \mathit{with} \\
\begin{array}{ll} \mid \mathit{Empty} & \to e_0 \\ \mid \mathit{Cons}\ a\ \mathit{as} & \to e_s \end{array}
\end{array}}
\text{ as syntactic sugar for }
\boxed{e\ e_0\ (\lambda a.\lambda\mathit{as}.e_s)}
$$

Note that this is untyped Lambda Calculus; the lists work for any type (including inhomogeneous).

### Summing a list of natural numbers

$$
\begin{array}{l}
\mathit{let}\ \mathit{rec}\ \mathit{suml}\ l = \mathit{match}\ l\ \mathit{with} \\
\quad \mid \mathit{Empty} \to\ 0 \\
\quad \mid \mathit{Cons}\ a\ \mathit{as} \to \mathit{add}\ a\ (\mathit{suml}\ \mathit{as})
\end{array}
$$

### Map

$$
\begin{array}{l}
\mathit{let}\ \mathit{rec}\ \mathit{map}\ f\ l = \mathit{match}\ l\ \mathit{with} \\
\quad \mid \mathit{Empty} \to\ \mathit{Empty} \\
\quad \mid \mathit{Cons}\ a\ \mathit{as} \to \mathit{Cons}\ (f\ a)\ (\mathit{map}\ f\ \mathit{as})
\end{array}
$$

## Slide 24 of 24: Exercises

Make some definitions in Pure Lambda Calculus - you can use all definitions we have introduced in the lecture

* Define the boolean function $\mathit{xor}$ (exclusive or). One can define $\mathit{xor}\ a\ b$ as “$a$ or $b$, but not both $a$ and $b$”. Try to define it in a way that it does not need so many reductions.
* A definition for addition was given using the fixedpoint combinator $Y$ (instead of recursion). Give a similar definition for multiplication and factorial, using the fixedpoint combinator $Y$. (Multiplication can use addition of course, and factorial can use multiplication.)
* For lists, define $\mathit{fold}$ and use it to re-define $\mathit{suml}$.

From the summer 2025 exam

https://www.imm.dtu.dk/ mire/FSharpBook/OldExams/02157-2025summer.pdf

consider

* Problem 2 without subtask 4 (we come to tail recursion later)
* Problem 3 without subtask 2 (same reason)
