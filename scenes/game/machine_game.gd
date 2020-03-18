extends Control

var press = []

func _on_red_pressed():
	press.append(3)
	$Container/HBoxContainer/red.disabled = true
	if press.size() == 3:
		validate()
	pass # Replace with function body.


func _on_yellow_pressed():
	press.append(1)
	$Container/HBoxContainer/yellow.disabled = true
	if press.size() == 3:
		validate()
	pass # Replace with function body.


func _on_blue_pressed():
	press.append(2)
	$Container/HBoxContainer/blue.disabled = true
	if press.size() == 3:
		validate()
	pass # Replace with function body.

func validate():
	for i in range(3):
		if press[i] != i+1:
			#errou
			pass
		pass
	pass

func setup():
	press = []
	$Container/HBoxContainer/blue.disabled = false
	$Container/HBoxContainer/red.disabled = false
	$Container/HBoxContainer/yellow.disabled = false
	pass


func _on_Exit_pressed():
	
	pass # Replace with function body.
