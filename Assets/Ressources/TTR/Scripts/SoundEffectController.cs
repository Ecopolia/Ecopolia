using UnityEngine;

public class SoundEffectController : MonoBehaviour
{
	[SerializeField]
	private SoundType m_sound_type;

	[SerializeField]
	private float m_delay;

	[SerializeField]
	private bool m_loop;

	[SerializeField]
	private bool m_play_on_enable;

	[SerializeField]
	private bool m_wait_for_world;

	public void play()
	{
	}

	public void stop()
	{
	}

	private void play_callback()
	{
	}

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}
}
