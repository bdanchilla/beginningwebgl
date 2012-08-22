function setupSphereMesh(n, options)
{
	options = options || {}; //ensures that we have a JSON object

	color = (typeof options.color !== 'undefined') ? options.color : [1.0, 0.0, 0.0, 1.0];
	translation = (typeof options.translation !== 'undefined') ? options.translation : [0.0, 0.0, 0.0];
	radius = (typeof options.radius !== 'undefined') ? options.radius : 1.0;
	divisions = (typeof options.divisions !== 'undefined') ? options.divisions : 30;
	smooth_shading = (typeof options.smooth_shading !== 'undefined') ? options.smooth_shading : true;
	textured = (typeof options.textured !== 'undefined') ? options.textured : false;

	var latitudeBands = divisions,
		longitudeBands = divisions;

	var vertexPositionData = [],
		normalData = [],
		colorData = [],
    	indexData = [],
    	textureData = [];
	
	//modified from http://learningwebgl.com/cookbook/index.php/How_to_draw_a_sphere
	for (var latNumber = 0; latNumber <= latitudeBands; latNumber++) {
	    var theta = latNumber * Math.PI / latitudeBands;
	    var sinTheta = Math.sin(theta);
	    var cosTheta = Math.cos(theta);
	 
	    for (var longNumber = 0; longNumber <= longitudeBands; longNumber++) {
	      var phi = longNumber * 2 * Math.PI / longitudeBands;
	      var sinPhi = Math.sin(phi);
	      var cosPhi = Math.cos(phi);
	 
	      var x = cosPhi * sinTheta;
	      var y = cosTheta;
	      var z = sinPhi * sinTheta;
	      var u = 1- (longNumber / longitudeBands);
	      var v = latNumber / latitudeBands;
	 
	 	  textureData.push((x + 1.0) * .5);
          textureData.push((y + 1.0) * .5);

	      normalData.push(x);
	      normalData.push(y);
	      normalData.push(z);
	      colorData.push(color[0]);
	      colorData.push(color[1]);
	      colorData.push(color[2]);
	      colorData.push(color[3]);
	      vertexPositionData.push(radius * x + translation[0]);
	      vertexPositionData.push(radius * y + translation[1]);
	      vertexPositionData.push(radius * z + translation[2]);
	    }
	  }
	 
	  for (var latNumber = 0; latNumber < latitudeBands; latNumber++) {
	    for (var longNumber = 0; longNumber < longitudeBands; longNumber++) {
	      var first = (latNumber * (longitudeBands + 1)) + longNumber;
	      var second = first + longitudeBands + 1;
	      indexData.push(first);
	      indexData.push(second);
	      indexData.push(first + 1);
	 
	      indexData.push(second);
	      indexData.push(second + 1);
	      indexData.push(first + 1);
	    }
	  }

	  if(!smooth_shading)
	  {
	  		vertexPositionData = calculateFlattenedVertices(vertexPositionData, indexData);
	  		colorData = [];
	  		for(var i=0; i<indexData.length;++i)
	  		{
	  			colorData.push(color[0]);
	      		colorData.push(color[1]);
		        colorData.push(color[2]);	      
		        colorData.push(color[3]);
	  		}	
	  		normalData = calculatePerFaceNormals(normalData, indexData);
	  }

	  trianglesNormalBuffers[n] = gl.createBuffer();
	  gl.bindBuffer(gl.ARRAY_BUFFER, trianglesNormalBuffers[n]);
	  gl.bufferData(gl.ARRAY_BUFFER, new Float32Array(normalData), gl.STATIC_DRAW);
	  trianglesNormalBuffers[n].itemSize = 3;
	  trianglesNormalBuffers[n].numItems = normalData.length / 3;
	 
	  trianglesColorBuffers[n] = gl.createBuffer();
	  gl.bindBuffer(gl.ARRAY_BUFFER, trianglesColorBuffers[n]);
	  gl.bufferData(gl.ARRAY_BUFFER, new Float32Array(colorData), gl.STATIC_DRAW);
	  trianglesColorBuffers[n].itemSize = 4;
	  trianglesColorBuffers[n].numItems = colorData.length / 4;

	  trianglesVerticeBuffers[n] = gl.createBuffer();
	  gl.bindBuffer(gl.ARRAY_BUFFER, trianglesVerticeBuffers[n]);
	  gl.bufferData(gl.ARRAY_BUFFER, new Float32Array(vertexPositionData), gl.STATIC_DRAW);
	  trianglesVerticeBuffers[n].itemSize = 3;
	  trianglesVerticeBuffers[n].numItems = vertexPositionData.length / 3;
	 
	  if(textured)
	  {
		  trianglesTexCoordBuffers[n] = gl.createBuffer();
		  gl.bindBuffer(gl.ARRAY_BUFFER, trianglesTexCoordBuffers[n]);
		  gl.bufferData(gl.ARRAY_BUFFER, new Float32Array(textureData), gl.STATIC_DRAW);
		  trianglesTexCoordBuffers[n].itemSize = 2;
		  trianglesTexCoordBuffers[n].numItems = textureData.length / 2;	  	
	  }

	  vertexIndexBuffers[n] = gl.createBuffer();
	  gl.bindBuffer(gl.ELEMENT_ARRAY_BUFFER, vertexIndexBuffers[n]);
	  gl.bufferData(gl.ELEMENT_ARRAY_BUFFER, new Uint16Array(indexData), gl.STREAM_DRAW);
	  vertexIndexBuffers[n].itemSize = 3;
	  vertexIndexBuffers[n].numItems = indexData.length;
}

function calculateFlattenedVertices(origVertices, indices)
{
	var vertices = [];
	for(var i=0; i<indices.length; ++i)
	{
		a = indices[i]*3;
		vertices.push(origVertices[a]);
		vertices.push(origVertices[a + 1]);
		vertices.push(origVertices[a + 2]);
	}	
	return vertices;
}

function calculatePerFaceNormals(origNormals, indices)
{
	var normals = [];
	for(var i=0; i<indices.length; i+=3)
	{
		var a = indices[i]*3;
		var b = indices[i+1]*3;
		var c = indices[i+2]*3;
		
		n1 = new Vector3(origNormals[a], origNormals[a+1], origNormals[a+2]);
		n2 = new Vector3(origNormals[b], origNormals[b+1], origNormals[b+2]);
		n3 = new Vector3(origNormals[c], origNormals[c+1], origNormals[c+2]);

		nx = (n1.x + n2.x + n3.x)/3;
		ny = (n1.y + n2.y + n3.y)/3;
		nz = (n1.z + n2.z + n3.z)/3;

		v3 = new Vector3(nx,ny,nz);
		normals.push(v3.x);
		normals.push(v3.y);
		normals.push(v3.z);

		normals.push(v3.x);
		normals.push(v3.y);
		normals.push(v3.z);

		normals.push(v3.x);
		normals.push(v3.y);
		normals.push(v3.z);
	}	
	return normals;
}
