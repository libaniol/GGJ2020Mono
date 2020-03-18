extends KinematicBody

var path = []
var path_ind = 0
var in_range : bool = false

onready var timer : Timer = get_node("chasing_timer") as Timer

export var move_speed : float = 0.0

onready var nav = get_parent()
onready var player = nav.get_node("Player")

func _physics_process(delta):
	if path_ind < path.size():
		var move_vec : Vector3 = (path[path_ind] - global_transform.origin)
		var direction = move_vec.normalized()
		rotation.y = atan2(direction.x, direction.z)
		if move_vec.length() < 0.1:
			path_ind += 1
		else:
			move_and_slide(direction * move_speed, Vector3(0, 1, 0))
	if in_range:
		var space_state = get_world().direct_space_state
		var from : Vector3 = global_transform.origin
		var to : Vector3 = player.global_transform.origin
		var result = space_state.intersect_ray(from, to, [self])
		if result:
			if result.collider.is_in_group("player"):
				get_tree().quit()

func move_to():
	path = nav.get_simple_path(global_transform.origin, player.global_transform.origin)
	path_ind = 0
	pass


func _on_chasing_timer_timeout():
	move_to()
	pass


func _on_FOV_body_entered(body):
	if body.is_in_group("player"):
		in_range = true
		pass
	pass


func _on_FOV_body_exited(body):
	if body.is_in_group("player"):
		in_range = false
	pass
