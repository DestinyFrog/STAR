import serial
import json

port = 'COM4'
baudrate = 9600

def sort_f(d):
	return d["data"]

ser = serial.Serial(port, baudrate)
for i in range(5):
	ser.readline()

max_r = 1
max_g = 1
max_b = 1
max_a = 1

min_r = 1000000
min_g = 1000000
min_b = 1000000
min_a = 1000000

while True:
	crude_data = ser.readline()
	str_data = str(crude_data)[2:-5]
	json_data = json.loads(str_data)

	r = json_data['r']
	g = json_data['g']
	b = json_data['b']
	a = json_data['a']

	# Max RGBA
	if r > max_r:
		max_r = r

	if g > max_g:
		max_g = g

	if b > max_b:
		max_b = b

	if a > max_a:
		max_a = a

	# Min RGBA
	if r < min_r:
		min_r = r

	if g < min_g:
		min_g = g

	if b < min_b:
		min_b = b

	if a < min_a:
		min_a = a

	print("---")
	print( ",".join([str(max_r), str(min_r), str(max_g), str(min_g), str(max_b), str(min_b), str(max_a), str(min_a)]) )