
#version 330 core
layout (location = 0) in vec3 aPos;
layout (location = 1) in vec3 aNormal;

out vec3 FragPos;
out vec3 Normal;

uniform mat4 model;
uniform mat4 view;
uniform mat4 projection;

void main()
{
    //把顶点位置属性乘以模型矩阵来把它变换到世界空间坐标
    FragPos = vec3(model * vec4(aPos, 1.0));
    Normal = aNormal;
    
    gl_Position = projection * view * vec4(FragPos, 1.0);
}
