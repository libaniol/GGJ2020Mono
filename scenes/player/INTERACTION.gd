extends Spatial

onready var ray = get_parent().get_node("RayCast")

var tracking : bool = false
var tracked : Box = null

func _process(_delta):
	if Input.is_action_just_pressed("interaction"):
		if ray.is_colliding() and not tracking:
			var collision = ray.get_collider()
			if collision:
				if collision.is_in_group("boxes"):
					tracked = collision as KinematicBody
					tracking = true
		elif tracking:
			tracked.velocity = Vector3()
			tracking = false
			tracked = null
	if tracking:
		tracked.velocity = get_parent().Velocity
