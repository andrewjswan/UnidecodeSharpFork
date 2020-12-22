import os, re
from xml.dom.minidom import Document

doc = Document()
caracters = doc.createElement("caracters")
doc.appendChild(caracters)

d = "unidecode"
print "working..."
for file in [file for file in os.listdir(d) if not file in [".",".."]]:
	m = re.search('x(.{3})\.py$', file)
	if m:
		data = __import__(d+"."+file[0:-3], [], [], ['data']).data
		c = 0
		num = int(m.group(1), 16)*255
		for ch in data:
			el = doc.createElement("char")
			el.setAttribute("code", str(num + c))
			el.setAttribute("value", ch)
			caracters.appendChild(el)
	
			#print str(num + c) + " " + ch #+" "+data[x]
			c=c+1
			
		#print dir() #+" "+m.group(1)

fp = open("chars.xml","w")
doc.writexml(fp, "    ", "", "\n", "UTF-8")

