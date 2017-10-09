require "./lib/morse"

puts "Enter a sentence or a word to translate"
user_message = gets.chomp.downcase  
Cher = MorseCode.new

puts "In Morse: "
puts Cher.convert(user_message)