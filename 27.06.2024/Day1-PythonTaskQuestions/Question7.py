def is_prime(num):
  if num <= 1:
    return False
  if num <= 3:
    return True
  # Check divisibility only by odd numbers from 3 to the square root of num (inclusive)
  for i in range(3, int(num**0.5) + 1, 2):
    if num % i == 0:
      return False
  return True

prime_sum = 0
prime_count = 0

# Get 10 numbers from the user
for i in range(10):
  number = int(input(f"Enter number {i+1}: "))
  if is_prime(number):
    prime_sum += number
    prime_count += 1

# Calculate and print the average (handle division by zero)
if prime_count > 0:
  average = prime_sum / prime_count
  print(f"Average of prime numbers: {average:.2f}")
else:
  print("No prime numbers found in the list.")
