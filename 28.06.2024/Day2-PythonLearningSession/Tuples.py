# Tuples are used to store multiple items in a single variable.
# Tuple items are ordered, unchangeable, and allow duplicate values.
# Tuples are unchangeable, meaning that we cannot change, add or remove items after the tuple has been created.

thistuple = ("apple", "banana", "cherry", "apple", "cherry")
print(thistuple)
tuple1 = ("abc", 34, True, 40, "male")
print(tuple1)

#Accessing Tuple
thistuple = ("apple", "banana", "cherry")
print(thistuple[1])

#Negative Indexing so from last
thistuple = ("apple", "banana", "cherry")
print(thistuple[-1])

#Accessing with Range (First value included and second values excluded)
thistuple = ("apple", "banana", "cherry", "orange", "kiwi", "melon", "mango")
print(thistuple[2:5])

#To change tuple values (Convert tuple to list and change and again convert to tuple)
x = ("apple", "banana", "cherry")
y = list(x)
y[1] = "kiwi"
x = tuple(y)
print(x)

#To add Items in tuple (Convert tuple to list and add and again convert to tuple)
thistuple = ("apple", "banana", "cherry")
y = list(thistuple)
y.append("orange")
thistuple = tuple(y)

#Adding tuple to a tuple
thistuple = ("apple", "banana", "cherry")
y = ("orange",)
thistuple += y
print(thistuple)

#Removing tuple values (Convert tuple to list and add and again convert to tuple)
thistuple = ("apple", "banana", "cherry")
y = list(thistuple)
y.remove("apple")
thistuple = tuple(y)

#Deleting complete tuple
thistuple = ("apple", "banana", "cherry")
del thistuple