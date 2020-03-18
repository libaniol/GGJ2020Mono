extends Camera

onready var player = get_parent().get_node("Player")

export var offset : Vector3

func _ready():
	var player_pos = player.global_transform.origin
	player_pos += offset
	global_transform.origin = player_pos


func _process(_delta):
	var player_pos = player.global_transform.origin
	player_pos += offset
	global_transform.origin = player_pos	
