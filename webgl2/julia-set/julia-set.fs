let fsSource = `#version 300 es
in highp vec2 position;
const int MAX_ITERATIONS = 150;
const highp float LIGHTNESS_FACTOR = 2.0;
out highp vec4 outputColor;

void main(void) {
    highp vec2 z = vec2(position.x, position.y);
    highp vec2 c = vec2(-.8,-.2);
    highp vec4 color = vec4(0.0, 0.0, 0.0, 1.0);

    for (int i = 0; i < MAX_ITERATIONS; i++)
    {
        z = vec2(z.x*z.x - z.y*z.y, 2.0*z.x*z.y) + c;

        if (dot(z, z) > 4.0)
        {
            highp float f =  LIGHTNESS_FACTOR*float(i) / float(MAX_ITERATIONS);
            color = vec4(vec3(0.1, 0.1, 1.0)*f, 1.0);
            break;
        }
    }
    outputColor = color;
}`;