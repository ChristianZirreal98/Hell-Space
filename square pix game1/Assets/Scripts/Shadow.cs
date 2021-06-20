using UnityEngine;

[RequireComponent(typeof(Light))]
public class Shadow : MonoBehaviour
{
    void OnEnable()
    {
        // Configurar distâncias de seleção de sombra
        var shadowCullDistances = new float[32];
        shadowCullDistances[8] = 5f; // Vamos imaginar que esta é a nossa camada de 'Objetos minúsculos'
        shadowCullDistances[8] = 15f; // Vamos imaginar que esta é nossa camada de 'Coisas Pequenas'
        shadowCullDistances[8] = 100f; // Vamos imaginar que esta é a nossa camada 'Árvores' 

        // Atribuir distâncias de seleção de sombra. Isso afetará apenas as camadas 10, 11 e 12.
        GetComponent<Light>().layerShadowCullDistances = shadowCullDistances;
        
    }

    void OnDisable()
    {
        // Desabilita completamente as distâncias de seleção de sombra
        GetComponent<Light>().layerShadowCullDistances = null;
    }
}