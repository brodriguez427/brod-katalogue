#ATM machines allow 4 or 6 digit PIN codes and PIN codes cannot contain anything but exactly 4 digits or exactly 6 digits.
#If the function is passed a valid PIN string, return true, else return false.

def validate_pin(pin):
  
    if len(pin) is 4 or len(pin) is 6:
        for i in pin:
            if i.isdigit():
              continue
            else:
                return False
        return True
    else:
        return False
            
    #return true or false
