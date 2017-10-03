# multiple of 3, fizz
# multiple of 5, buzz
# multiple of both, fizzbuzz

counter = 0

while counter < 100
   
    counter += 1
    number = counter

    if number % 15 == 0
        puts "fizzbuzz"
    elsif number % 3 == 0
        puts "fizz"
    elsif number % 5 ==0
        puts "buzz"
    else
     puts counter 
    end

end
