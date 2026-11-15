# 02157 Functional Programming, Week 10: Verification

Transcribed from `Lecture11-zeb.pdf`, 7 slides, one section per slide.

## Slide 1 of 7

**02157 Functional Programming**

**Week 10:**

**Verification**

Sebastian Mödersheim

Based on slides by Michael Reichhardt Hansen

November 13, 2026

## Slide 2 of 7: Overview

Part I:

* Guest Lecture by Oliver Bøving

  *Lean and mean: dependable software using dependent types and how it somehow ended up revolutionizing the world of mathematics in the process*

Part II:

* A verification exercise

## Slide 3 of 7: Propositional Logic

*Syntax*

A propositional formula is anything of the following:

* The constants `true`, `false`
* A Boolean variable (aka proposition) $x$ (Let $\mathcal{V}$ denote the set of all variables.)
* If $\phi, \phi_1, \phi_2$ are already propositional formulas then also
  * $\neg\phi$ (the negation)
  * $\phi \land \psi$ (the conjunction)
  * $\phi \lor \psi$ (the disjunction)

**Task**: Implement an F# datatype `PF` for this.

Many other operators can be introduced as *syntactic sugar*:¹

* $\phi \to \psi = \neg\phi \lor \psi$
* $\phi \leftrightarrow \psi = \phi \to \psi \land \psi \to \phi$
* $\phi \oplus \psi = \neg(\phi \leftrightarrow \psi)$

**Task**: implement F# functions `implies`, `equiv`, and `xor`, each of type $\texttt{PF} \star \texttt{PF} \to \texttt{PF}$, for the syntactic sugar.

¹ Even disjuntion could rather be defined as syntactic sugar: $\phi \lor \psi = \neg(\neg\phi \land \neg\psi)$

## Slide 4 of 7: Propositional Logic

*Semantics*

An *interpretation $\mathcal{I}$* is a function that maps from the variables $\mathcal{V}$ to $\{\texttt{true}, \texttt{false}\}$.

### Semantics

We define than an interpretation $\mathcal{I}$ *satisfies* a formula $\phi$, written *$\mathcal{I} \models \phi$*, as follows:

$$
\begin{array}{lll}
\mathcal{I} \models \texttt{true} \\
\mathcal{I} \not\models \texttt{false} \\
\mathcal{I} \models x & \text{iff} & \mathcal{I}(x) = \texttt{true} \\
\mathcal{I} \models \neg\phi & \text{iff} & \mathcal{I} \not\models \phi \\
\mathcal{I} \models \phi \land \psi & \text{iff} & \mathcal{I} \models \phi \text{ and } \mathcal{I} \models \psi \\
\mathcal{I} \models \phi \lor \psi & \text{iff} & \mathcal{I} \models \phi \text{ or } \mathcal{I} \models \psi
\end{array}
$$

One sometimes also says *$\mathcal{I}$ is a model of $\phi$* instead of $\mathcal{I}$ satisfies $\phi$.

**Task**: Implement an F# function `models` that takes a `PF` and an interpretation $\mathcal{I}$ (define an appropriate datatype) and returns a bool.

Examples:

* the formula $x \lor \neg x$ is true for every interpretation.
* the formula $(s_0 \leftrightarrow (a \oplus b \oplus c)) \land (s_1 \leftrightarrow (a \land b \lor ((a \oplus b) \land c)))$ is satisfiable for instance if $\mathcal{I}$ gives true for $a, b, s_1$ and false for all other variables.

## Slide 5 of 7: Satisfiability

A formula $\phi$ is called *satisfiable* iff there is an interpretation $\mathcal{I}$ with $\mathcal{I} \models \phi$.

A formula $\phi$ is called *valid* iff for every interpretation $\mathcal{I}$, $\mathcal{I} \models \phi$.

Two formulas $\phi$ and $\psi$ are called *equivalent*, written $\phi \equiv \psi$ iff they are satisfied for exactly the same interpretations.

### Naïve algorithm for satisfiability

For a formula $\phi$ with variables $x_1, \ldots, x_n$

* Consider all $2^n$ interpretations that map the $x_i$ to `true` or `false`.
* Check for each such interpretation, whether it satisfies $\phi$.

**Task**: implement this naïve algorithm where you first collect all the variables in a set and then use the `models` function from before. Preferably, your implementation does not construct all the interpretations in memory.

**Task**: implement a function to check validity of a formula, based on the satisfiability algorithm, using the fact that $\phi$ is valid iff $\neg\phi$ is unsatisfiable (i.e., not satisfiable)

**Task**: implement a function to check whether two formulas are equivalent using the validity algorithm, using the fact that $\phi$ is equivalent to $\psi$ iff $\phi \leftrightarrow \psi$ is valid.

## Slide 6 of 7: Satisfiability

### Complexity

* The naïve algorithm needs time $O(2^n)$ if the formula contains $n$ variables.
* One can design algorithms that better on many formulas. $\Rightarrow$ SAT Competition
* Is there an algorithm for satisfiability that is in *polynomial time $O(n^k)$* *in the worst case* (for some constant $k$)?
  * Open problem!
    * Neither an algorithm is known nor a proof that this is impossible.
  * If there is, you would automatically have a polynomial algorithm to break almost all cryptography!
  * There is a class of problems for which we know that they are exactly as hard as SAT: *NP-complete problems*.
    * Either all have a polynomial algorithm or none.
    * This is the famous open *$P \stackrel{?}{=} NP$ problem.*

## Slide 7 of 7: Towards a better algorithm

We will not solve the $P \stackrel{?}{=} NP$ in this course `:-P` but we take a look at a basic algorithm with better efficiency for many formulas.

Today just a step towards that:

### Negation Normal Form

A formula (without syntactic sugar) is said to be in *negation normal form* iff negation only occurs on variables.

Example: $\neg(x \lor \neg x)$ is not in negation normal form, but we can transform it into an equivalent formula in negation normal form:

$$
\neg(x \lor \neg x) \equiv (\neg x) \land (\neg\neg x) \equiv (\neg x) \land x
$$

**Task:** Write a function `NN` that transforms a given `PF` into an equivalent formula in negation normal form.
