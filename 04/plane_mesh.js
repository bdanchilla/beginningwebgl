function setupPlaneMesh(n, options)
{
	options = options || {}; //ensures that we have a JSON object

	size = (typeof options.size !== 'undefined') ? options.size : 10.0;
	color = (typeof options.color !== 'undefined') ? options.color : [0.5, 0.5, 1.0, 1.0];
	translation = (typeof options.translation !== 'undefined') ? options.translation : [0.0, 0.0, 0.0];
	textured = (typeof options.textured !== 'undefined') ? options.textured : false;

	var vertexPositionData = [],
		normalData = [],
		colorData = [],
    	indexData = [],
    	textureData = [];

	  //plane
	  for(var i=0; i<5;++i)
	  {
	      normalData.push(0.0);
	      normalData.push(1.0);
	      normalData.push(0.0);
	      colorData.push(color[0]);
	      colorData.push(color[1]);
	      colorData.push(color[2]);
	      colorData.push(color[3]);
	  }

    vertexPositionData = [
      		  0.0, 0.0,  0.0,
      		-size, 0.0, -size,
      		size, 0.0, -size,
      		size, 0.0, size,
      		-size, 0.0, size      	
  	];

  	textureData = [
  		  0.0, 0.0,
  		-size, -size,
  		size, -size,
  		size, size,
  		-size, size      	
  	];


  	for(var j=0;j<vertexPositionData.length;j+=3)
  	{
			vertexPositionData[j] += translation[0];
			vertexPositionData[j + 1] += translation[1];
			vertexPositionData[j + 2] += translation[2];
  	}

      indexData = [0,1,2,0,2,3,0,3,4,0,4,1];

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
