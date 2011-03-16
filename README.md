# ScoreSharp

ScoreSharp is a fuzzy string search algorithm.

## What it does

 * It tells how much a string matches another one
 * It can sort your string arrays from the the best scored 'til the end
 * It can't bring you a beer

## How to use it

It's simple:

 * Call it like:
>	ScoreSharp.score("I want to find something here", "something") // => Shows the percentage score
>	ScoreSharp.score("I want to use some fuzzy", "som fuzy", 0.12) // => Shows the percentage, even with some mistakes
 * Or use it to sort:
>	string[] myList = new string[] { "Hi!","Hello","Hi and Hello", "Hello there!" };
>	myList = ScoreSharp.sorter(at, "Hello");

## Credits

It's based on the [string_score](https://github.com/joshaven/string_score) from [Joshaven Potter](https://github.com/joshaven/).


