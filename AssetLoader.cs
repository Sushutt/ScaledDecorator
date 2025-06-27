using UnityEngine;

/*
    ScaledDecorator is a plugin for KSP that loads AssetBundles into ScaledSpace.
*/

namespace ScaledDecorator
{
    [KSPAddon(KSPAddon.Startup.PSystemSpawn, false)]
    public class AssetBundleLoader : MonoBehaviour
    {
        readonly string configName = "ScaledDecoratorObject";

        public void Start()
        {
            UrlDir.UrlConfig[] configs = GameDatabase.Instance.GetConfigs(configName);
            Debug.Log("Loading ScaledDecorator configs..");
            foreach (UrlDir.UrlConfig file in configs)
            {
                ScaledAsset asset = new ScaledAsset();

                ConfigNode config = file.config;
                Debug.Log($"Loading ConfigFile {file.url}");

                asset.assetPath = config.GetValue("assetBundle");
                asset.prefabName = config.GetValue("prefab");
                asset.planetName = config.GetValue("parent");
                asset.rotatesWithParent = config.GetValue("rotatesWithParent").ToLower() == "true";
                asset.rotation = ConfigNode.ParseVector3(config.GetValue("rotation"));
                asset.rotationSpeed = ConfigNode.ParseVector3(config.GetValue("rotationSpeed"));
                asset.localPosition = ConfigNode.ParseVector3(config.GetValue("localPosition"));

                // Tell the asset to instantiate itself
                asset.CreateInstance();

                Debug.Log($"Successfully loaded Asset {asset.assetPath}");
            }
            Debug.Log("ScaledDecorator loading done!");
        }
    }

    public class ScaledAsset
    {
        public string assetPath; // Path to the AssetBundle. Starts from GameData
        public string prefabName; // Name of the prefab that we want to instantiate
        public string planetName;
        public bool rotatesWithParent;
        public Vector3 rotation; // Initial rotation
        public Vector3 rotationSpeed; // Degrees per second
        public Vector3 localPosition;

        // Create itself
        public void CreateInstance()
        {
            // Get bundle
            Debug.Log($"Instantiating Asset {assetPath}");
            string path = KSPUtil.ApplicationRootPath + "GameData/" + assetPath;
            AssetBundle asset = AssetBundle.LoadFromFile(path);

            // Load the prefab
            var prefab = asset.LoadAsset<GameObject>(prefabName);
            GameObject thingy = Object.Instantiate(prefab);

            // Set parent
            CelestialBody cBody = FlightGlobals.GetBodyByName(planetName);
            thingy.transform.parent = cBody.scaledBody.transform;

            // Miscellaneous nonsense
            thingy.transform.localPosition = localPosition;
            if (rotatesWithParent)
            {
                thingy.transform.localRotation = Quaternion.Euler(
                    rotation.x,
                    rotation.y,
                    rotation.z
                );
            }
            else
            {
                IndependentRotation rotationScript = thingy.AddComponent<IndependentRotation>();
                rotationScript.currentRotation = rotation;
                rotationScript.rotationDirection = rotationSpeed;
            }
            SetRenderLayer(thingy, 10);

            // Unload the asset for the future™️
            asset.Unload(false);
        }

        // Dark and twisted recursive function for setting the render layer of all things
        // Layer 10 is ScaledScenery
        public static void SetRenderLayer(GameObject go, int layer)
        {
            foreach (Transform t in go.transform)
            {
                t.gameObject.layer = layer;
                SetRenderLayer(t.gameObject, layer);
            }
        }
    }

    // Small script that controls the rotation of an object
    public class IndependentRotation : MonoBehaviour
    {
        public Vector3 rotationDirection = Vector3.zero;
        public Vector3 currentRotation = Vector3.zero;

        public void Update()
        {
            currentRotation += rotationDirection * Time.deltaTime * TimeWarp.CurrentRate;
            transform.rotation = Quaternion.Euler(
                currentRotation.x,
                currentRotation.y,
                currentRotation.z
                );
        }
    }
}
