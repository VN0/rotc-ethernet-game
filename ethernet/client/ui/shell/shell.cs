//------------------------------------------------------------------------------
// Revenge Of The Cats: Ethernet
// Copyright (C) 2008, mEthLab Interactive
//------------------------------------------------------------------------------

//------------------------------------------------------------------------------
// Revenge Of The Cats - shell.cs
// Code for Revenge Of The Cats' Shell
//------------------------------------------------------------------------------

if(isObject(DefaultCursor))
{
    DefaultCursor.delete();

    new GuiCursor(DefaultCursor)
    {
	   hotSpot = "1 1";
	   bitmapName = "./pixmaps/mg_3darrow";
    };
}

function addWindow(%control)
{
	if(Canvas.getContent() == Shell.getId())
		Shell.add(%control);
	else
		ShellDlg.add(%control);

	%control.onAddedAsWindow();
	Canvas.repaint();
}

function removeWindow(%control)
{
	%control.getParent().remove(%control);
	%control.onRemovedAsWindow();
	Canvas.repaint();
}

function Shell::onWake()
{

}

function ShellRoot::onMouseDown(%this,%modifier,%coord,%clickCount)
{
	//
	// display the root menu...
	//

	if( Shell.isMember(RootMenu) )
		removeWindow(RootMenu);
	else
	{
		RootMenu.position = %coord;
		addWindow(RootMenu);
		//Canvas.repaint();
	}
}

function ShellRoot::onMouseEnter(%this,%modifier,%coord,%clickCount)
{
 //
}

