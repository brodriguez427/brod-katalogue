
message_store = []

stop = false
i = 0

while stop == false
    
    puts "Would you like to (s)tore a message,(r)etrieve a message or e(x)it?"
    response = gets.downcase.chomp
    
    if response == "s"
        puts "Please record your message"
        message = gets.chomp
        message_store[i] = message
        puts "Your message id is #{i}"
        i += 1
    elsif response == "r"
        puts "Enter your message id"
        message_id = gets.to_i
        puts "Message #{message_id}: #{message_store[message_id]}" 
    elsif response == "x"
        stop = true
    else
        puts "Try again, buddy."
    end
    
end
