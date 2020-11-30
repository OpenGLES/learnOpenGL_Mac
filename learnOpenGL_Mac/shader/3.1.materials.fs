#version 330 core
out vec4 FragColor;

struct Material {
    vec3 ambient;//环境光照
    vec3 diffuse;//漫反射
    vec3 specular;//镜面光照对物体的颜色影响
    float shininess;//镜面高光的散射/半径
};

struct Light {
    vec3 position;

    vec3 ambient;
    vec3 diffuse;
    vec3 specular;
};

in vec3 FragPos;
in vec3 Normal;
  
uniform vec3 viewPos;
uniform Material material;
uniform Light light;

void main()
{
    // ambient 环境光
    vec3 ambient = light.ambient * material.ambient;
      
    // diffuse 漫反射
    vec3 norm = normalize(Normal);
    vec3 lightDir = normalize(light.position - FragPos);
    float diff = max(dot(norm, lightDir), 0.0);
    vec3 diffuse = light.diffuse * (diff * material.diffuse);
    
    // specular 镜面光
    vec3 viewDir = normalize(viewPos - FragPos);
    vec3 reflectDir = reflect(-lightDir, norm);
    float spec = pow(max(dot(viewDir, reflectDir), 0.0), material.shininess);
    vec3 specular = light.specular * (spec * material.specular);
        
    vec3 result = ambient + diffuse + specular;
    FragColor = vec4(result, 1.0);
}