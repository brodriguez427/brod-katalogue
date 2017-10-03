puts "Please enter your name"
name = gets.chomp

if name.include? "B"
    puts "#{name.capitalize.chomp}, what a lovely name".chomp
end

if name.each_char.any? {|x| x == "e"}
puts "very classy".chomp
end

if name.length >= 5
    puts "...but certainly a mouthful!"
end

puts "How old are you?"
age = gets.to_i
age = age + 5
puts "You will be #{age} in 5 years"

