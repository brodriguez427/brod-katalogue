puts "What is the length of your garden box?"
length = gets.to_f

puts "What is the width of your garden box?"
width = gets.to_f

area = length * width
perimeter = 2 * (length + width)

puts "The area of your garden box is #{area}"
puts "The perimeter of your box is #{perimeter}" 

number_carrots = area * 1.0
number_corn = area * 3/16.0
number_beets = area * 9/16.0

puts "You can plant #{number_carrots.floor} carrots, #{number_corn.floor} corn or #{number_beets.floor} beets."

