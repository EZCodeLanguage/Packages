# Main

Contains the basic functionality for EZCode (automatically included in build).
- `bool`, `str`, `float`, `int`, `char`, `expressions`, `var`, and `list` classes
- `print`, `input`, `runcode`, `clear`, `regexmatch`, `environment`, and `istype` methods. Basic global math functions
  
```
bool b new : True
str s new : Hello World
float f new : 1.23
int i new : 123
char c new : A
var v new : any
list l new : 1;2;3
(5 * 5) // expression -- explicit watch \((.* {EXP})\)
print Hello World! // prints to console
input // waits for the user to input
clear // clears the console
runcode undefined val => any // this runs any ezcode
regex-match : text, \/hello|\/world
is-type : #varname /*add the # before variable name*/, str
add 5, 10
subtract 5, 10
multiply 5, 10
divide 5, 10
pi // returns pi constant
clamp 50, 10, 100 // clamps number '50' between '10' and '100'
random 0, 100
round-to-int 0.5684
avg 10, 20, 30, 40, 50, 100000 // returns the average of the numbers
operate sin, 50 // returns the sin of 50
str user new => environment : username
```
