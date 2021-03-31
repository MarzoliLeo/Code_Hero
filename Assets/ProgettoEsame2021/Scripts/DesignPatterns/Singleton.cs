using UnityEngine;

namespace ProgettoEsame2021.Scripts.DesignPatterns
{
	public abstract class Singleton<T> : MonoBehaviour where T : Component //Puo' solo essere una classe ( :Component)
	{
		//L'istanza.
		private static T instance;
		
		//Prende l'istanza.
		public static T Instance
		{
			get
			{
				if ( instance == null )
				{
					instance = FindObjectOfType<T> ();
					if ( instance == null )
					{
						GameObject obj = new GameObject ();
						obj.name = typeof ( T ).Name;
						instance = obj.AddComponent<T> ();
					}
				}
				return instance;
			}
		}
		
		//Usa questa funzione per l'inizializzazione.
		protected virtual void Awake ()
		{
			if ( instance == null )
			{
				instance = this as T;
				DontDestroyOnLoad ( gameObject );
			}
			else
			{
				Destroy ( gameObject );
			}
		}
		
	}
}

