using System;
using System.Runtime.CompilerServices;
using UnityEngine;

public class VisualEffectBase : MonoBehaviour, IPoolResource
{
	[SerializeField]
	protected float m_life_span;

	protected ParticleSystem[] m_particle_systems;

	protected Transform m_transform;

	protected bool m_is_playing;

	public string ResourceFilePath
	{
		[CompilerGenerated]
		get
		{
			return null;
		}
		[CompilerGenerated]
		set
		{
		}
	}

	public float LifeSpan
	{
		[CompilerGenerated]
		get
		{
			return 0f;
		}
		[CompilerGenerated]
		protected set
		{
		}
	}

	public Vector3 Position
	{
		get
		{
			return default(Vector3);
		}
		set
		{
		}
	}

	public Transform Parent
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public static event Action<VisualEffectBase> on_visual_effect_complete_event
	{
		[CompilerGenerated]
		add
		{
		}
		[CompilerGenerated]
		remove
		{
		}
	}

	public virtual bool on_spawned(float duration_override = 0f)
	{
		return false;
	}

	public void return_to_pool(bool send_to_recycling = false)
	{
	}

	protected void on_complete()
	{
	}

	protected virtual void OnDisable()
	{
	}

	protected virtual void Awake()
	{
	}
}
