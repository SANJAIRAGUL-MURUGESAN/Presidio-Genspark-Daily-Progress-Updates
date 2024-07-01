#Handling errors in general
a = [1, 2, 3]
try: 
    print ("Second element = %d" %(a[1]))
 
    print ("Fourth element = %d" %(a[3]))
 
except:
    print ("An error occurred")

#Handling Specific errors
def fun(a):
    if a < 4:
 
        b = a/(a-3)
    print("Value of b = ", b)
try:
    fun(3)
    fun(5)
except ZeroDivisionError:
    print("ZeroDivisionError Occurred and Handled")
except NameError:
    print("NameError Occurred and Handled")

#with else clause
def AbyB(a , b):
    try:
        c = ((a+b) / (a-b))
    except ZeroDivisionError:
        print ("a/b result in 0")
    else:
        print (c)
AbyB(2.0, 3.0)
AbyB(3.0, 3.0)


#Exception Handling with Finally
try:
    k = 5//0
    print(k)
 
except ZeroDivisionError:
    print("Can't divide by zero")
 
finally:
    print('This is always executed')