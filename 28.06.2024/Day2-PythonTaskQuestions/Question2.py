def is_prime(num):
  if num <= 1:
    return False
  for i in range(2, num):
    if num % i == 0:
      return False
  return True

def print_primes(n):
  print("Prime numbers up to", n, ":")
  for i in range(2, n + 1):
    if is_prime(i):
      print(i)

# User Input and function calling
n = int(input("Enter the number: "))
print_primes(n)
