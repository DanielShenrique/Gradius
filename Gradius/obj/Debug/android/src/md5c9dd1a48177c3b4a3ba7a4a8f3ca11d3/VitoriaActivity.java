package md5c9dd1a48177c3b4a3ba7a4a8f3ca11d3;


public class VitoriaActivity
	extends android.app.Activity
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"";
		mono.android.Runtime.register ("Gradius.VitoriaActivity, Gradius, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", VitoriaActivity.class, __md_methods);
	}


	public VitoriaActivity ()
	{
		super ();
		if (getClass () == VitoriaActivity.class)
			mono.android.TypeManager.Activate ("Gradius.VitoriaActivity, Gradius, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void onCreate (android.os.Bundle p0)
	{
		n_onCreate (p0);
	}

	private native void n_onCreate (android.os.Bundle p0);

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
