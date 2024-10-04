VAR hasKey = false
->start
== start ==
You are standing in front of a locked door.
 * {hasKey} [Use the key to open the door.]->door_open
 * [Look for a key.]
  -> found_key

== found_key ==
You find a key! 
~ hasKey = true
-> start

== door_open ==
Door Open !! -> DONE