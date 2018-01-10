let gl = null,
    canvas = null,
    glProgram = null,
    fragmentShader = null,
    vertexShader = null;

let vertexPositionAttribute = null,
    trianglesVerticeBuffer = null,
    vertexIndexBuffer = null;

function initWebGL() {
    canvas = document.getElementById('my-canvas');
    try {
        gl = canvas.getContext('webgl2');
    } catch (e) {
        console.log(e);
    }

    if (gl) {
        gl = WebGLDebugUtils.makeDebugContext(gl);
        initShaders();
        createSquare();
        vertexPositionAttribute = gl.getAttribLocation(glProgram, 'aVertexPosition');
        gl.enableVertexAttribArray(vertexPositionAttribute);

        gl.viewport(0, 0, canvas.width, canvas.height);
        setupWebGL();
        drawScene();
    } else {
        alert('Error: Your browser does not appear to support WebGL.');
    }
}

function setupWebGL() {
    //set the clear color to a shade of green
    gl.clearColor(0.1, 0.5, 0.1, 1.0);
    gl.clear(gl.COLOR_BUFFER_BIT | gl.DEPTH_BUFFER_BIT);
    gl.enable(gl.DEPTH_TEST);
}

function initShaders() {
    //compile shaders
    vertexShader = makeShader(vsSource, gl.VERTEX_SHADER);
    fragmentShader = makeShader(fsSource, gl.FRAGMENT_SHADER);

    //create program
    glProgram = gl.createProgram();

    //attach and link shaders to the program
    gl.attachShader(glProgram, vertexShader);
    gl.attachShader(glProgram, fragmentShader);
    gl.linkProgram(glProgram);
    if (!gl.getProgramParameter(glProgram, gl.LINK_STATUS)) {
        alert('Unable to initialize the shader program.');
    }

    //use program
    gl.useProgram(glProgram);
}

function makeShader(src, type) {
    //compile the vertex shader
    let shader = gl.createShader(type);
    gl.shaderSource(shader, src);
    gl.compileShader(shader);
    if (!gl.getShaderParameter(shader, gl.COMPILE_STATUS)) {
        alert('Error compiling shader: ' + gl.getShaderInfoLog(shader));
    }
    return shader;
}

function drawScene() {
    gl.bindBuffer(gl.ARRAY_BUFFER, trianglesVerticeBuffer);
    gl.vertexAttribPointer(vertexPositionAttribute, 3, gl.FLOAT, false, 0, 0);
    gl.bindBuffer(gl.ELEMENT_ARRAY_BUFFER, vertexIndexBuffer);
    gl.drawElements(gl.TRIANGLES, vertexIndexBuffer.numItems, gl.UNSIGNED_SHORT, 0);
}

function createSquare(size) {
    size = (typeof size !== 'undefined') ? size : 1.0;
    let vertexPositionData = [
        0.0, 0.0, 0.0,
        -size, -size, 0.0,
        size, -size, 0.0,
        size, size, 0.0,
        -size, size, 0.0,
    ];
    let indexData = [0, 1, 2, 0, 2, 3, 0, 3, 4, 0, 4, 1];
    trianglesVerticeBuffer = gl.createBuffer();
    gl.bindBuffer(gl.ARRAY_BUFFER, trianglesVerticeBuffer);
    gl.bufferData(gl.ARRAY_BUFFER, new Float32Array(vertexPositionData), gl.STATIC_DRAW);
    trianglesVerticeBuffer.itemSize = 3;
    trianglesVerticeBuffer.numItems = vertexPositionData.length / 3;
    vertexIndexBuffer = gl.createBuffer();
    gl.bindBuffer(gl.ELEMENT_ARRAY_BUFFER, vertexIndexBuffer);
    gl.bufferData(gl.ELEMENT_ARRAY_BUFFER, new Uint16Array(indexData), gl.STREAM_DRAW);
    vertexIndexBuffer.itemSize = 3;
    vertexIndexBuffer.numItems = indexData.length;
}