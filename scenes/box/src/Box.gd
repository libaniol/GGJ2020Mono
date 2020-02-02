class_name Box

extends KinematicBody

export var gravity : float = 0.0
var velocity : Vector3 = Vector3()

func _process(delta):
	velocity.y += gravity * delta

func _physics_process(_delta):
	velocity = move_and_slide(velocity)
