# HTTP

Contains the functionality for basic HTTP requests.
- `datetime` class:
  - Methods:
    - `now` returns the current date and time as a string along with optional parameter to format it `datetime now : ? @str:format`
    - `utcnow` returns the utc date and time as a string along with optional parameter to format it `datetime utcnow : ? @str:format`
    - `today` returns today's date and time as a string along with optional parameter to format it `datetime today : ? @str:format`
    - `compare` returns `1`, `0`, or `-1` depending on the dates relation to the other date `datetime compare : @str:time1, @str:time2`
    - `unixepoch` returns the unix epoch date and time as a string along with optional parameter to format it `datetime unixepoch : ? @str:format`
    - `max-value` returns the max value date and time as a string along with optional parameter to format it `datetime max-value : ? @str:format`
    - `min-value` returns the min value date and time as a string along with optional parameter to format it `datetime min-value : ? @str:format`
    - `days-in-month` returns the days in the month as an int `datetime days-int-month : @str:_time`
    - `is-leep-year` returns if the year is a leep year `datetime is-leep-year : @str:_time`
    - `day-of-year` returns the day of the year as int `datetime day-of-year : @str:_time`
    - `day-of-week` returns the day of the week as str `datetime day-of-week : @str:_time`
    - `is-daylight-savings-time` returns if the year is in daylight savings time `datetime is-daylight-savings-time : @str:_time`
- `stopwatch` class:
  - Methods:
    - `start` starts a stopwatch instance that counts up 
    - `end` ends the stopwatch in the instance
    - `elapsed-nanoseconds` returns the elapsed nanoseconds from the stopwatch instance
    - `elapsed-miliseconds` returns the elapsed miliseconds from the stopwatch instance
    - `elapsed-seconds` returns the elapsed seconds from the stopwatch instance
    - `elapsed-minutes` returns the elapsed minutes from the stopwatch instance
    - `elapsed-hours` returns the elapsed hours from the stopwatch instance
- `timer` class:
  - Methods:
    - `new-instance` returns a new instance of the timer class based off of the variable values `new-instance : @int:hours, @int:minutes, @int:seconds, @int:miliseconds`
    - `start` starts a timer with the values from the instance properties
    - `stop` stops the timer instance
    - `resume` resumes the timer instance
    - `is-done` returns if the timer instance has elapsed
    - `is-not-done` returns if the timer instance has not elapsed
  - Properties:
    - `hours` the timer instance's hours
    - `minutes` the timer instance's minutes
    - `seconds` the timer instance's seconds
    - `miliseconds` the timer instance's miliseconds
 