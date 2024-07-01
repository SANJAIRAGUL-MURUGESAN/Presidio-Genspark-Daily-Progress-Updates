import MyModule as mx #user defined module
import platform  #built in Module
from MyModule import person1

#built in Module
x = platform.system()
print(x)

#imported user defined module
a = mx.person1["age"]
print(a)