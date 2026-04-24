class_name Dice
extends RigidBody3D

signal roll_finished(int)

var sides = {}
var rolling := false

func _physics_process(delta):
	if Input.is_action_just_pressed("ui_accept"):
		show_face()


func face_up_transform(value) -> Transform3D:
	"""Returns the 3D tranform to put the given value up"""
	var face_normal = (to_global(sides[value])-global_position).normalized()
	var cross = face_normal.cross(Vector3.UP).normalized()
	var angle = face_normal.angle_to(Vector3.UP)
	var rotated := Transform3D(transform)
	# Edge case: face is down
	if cross.length_squared()<0.1:
		cross = Vector3.FORWARD
	rotated.basis = rotated.basis.rotated(cross.normalized(), angle)
	return rotated


func show_face(value):
	"""Shows a given face by rotating it up"""
	assert(value in sides)
	rolling = true
	const show_face_animation_time := .3
	var rotated := face_up_transform(value)
	var tween: Tweener = create_tween().tween_property(
		self, "transform", rotated, show_face_animation_time
	)
	await tween.finished
	rolling = false
	roll_finished.emit(value)
