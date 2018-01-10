let vsSource = `#version 300 es
in vec3 aVertexPosition;

out vec2 position;
void main(void) {
    position = vec2(aVertexPosition.xy);
    gl_Position = vec4(position.xy, 0.0, 1.0);
}`;