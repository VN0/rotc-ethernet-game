//------------------------------------------------------------------------------
// Revenge Of The Cats: Ethernet
// Copyright (C) 2008, mEthLab Interactive
//------------------------------------------------------------------------------

// These are the functions that can be remapped to different controls
// using the "Controls" option dialog.

//------------------------------------------------------------------------------
// In-game shell overlay
//------------------------------------------------------------------------------

function toggleShellDlg(%val)
{
	if(%val)
		return;

	if(ShellDlg.isAwake())
		Canvas.popDialog(ShellDlg);
	else
	{
		Canvas.pushDialog(ShellDlg);
		addWindow(MissionWindow);
	}
}

//------------------------------------------------------------------------------
// Camera
//------------------------------------------------------------------------------

function freeLook( %val )
{
	$mvFreeLook = %val;
}

function toggleFirstPerson(%val)
{
	if (%val)
	{
		$firstPerson = !$firstPerson;
		ServerConnection.setFirstPerson($firstPerson);
	}
}

//------------------------------------------------------------------------------
// Movement
//------------------------------------------------------------------------------

function moveleft(%val)
{
	$mvLeftAction = %val;
}

function moveright(%val)
{
	$mvRightAction = %val;
}

function moveforward(%val)
{
	$mvForwardAction = %val;
}

function movebackward(%val)
{
	$mvBackwardAction = %val;
}

function moveup(%val)
{
	$mvUpAction = %val;
}

function movedown(%val)
{
	$mvDownAction = %val;
}

function turnLeft( %val )
{
	$mvYawRightSpeed = %val ? $Pref::Input::KeyboardTurnSpeed : 0;
}

function turnRight( %val )
{
	$mvYawLeftSpeed = %val ? $Pref::Input::KeyboardTurnSpeed : 0;
}

function panUp( %val )
{
	$mvPitchDownSpeed = %val ? $Pref::Input::KeyboardTurnSpeed : 0;
}

function panDown( %val )
{
	$mvPitchUpSpeed = %val ? $Pref::Input::KeyboardTurnSpeed : 0;
}

function yaw(%val)
{
	$mvYaw += getMouseAdjustAmount(%val);
}

function pitch(%val)
{
	$mvPitch += getMouseAdjustAmount(%val);
}

//------------------------------------------------------------------------------
// Triggers
//------------------------------------------------------------------------------

function trigger0(%val)
{
	// hack hack hack: players should really be able
    // to configure arbitrary chords.
	if($triggerDown[3] && %val)
	{
		// chord initiated
		$chording[0] = true;
		action12(1);
	}

	if($chording[0])
	{
		if(!%val)
		{
			// chord finished
			$chording[0] = false;
			action12(0);
		}			
	}
	else
	{
		$mvTriggerCount0++;
	}
}

function trigger1(%val)
{
	$mvTriggerCount1++;
}

function trigger2(%val)
{
	$mvTriggerCount2++;
}

function trigger3(%val)
{
	$mvTriggerCount3++;
	$triggerDown[3] = %val;
}

function trigger4(%val)
{
	$mvTriggerCount4++;
}

function trigger5(%val)
{
	$mvTriggerCount5++;
}

//------------------------------------------------------------------------------
// Zoom and FOV
//------------------------------------------------------------------------------

function toggleZoomLevel(%val)
{
	if(%val)
	{
		if( $CurrentZoomValue == 0 )
			$CurrentZoomValue = 5;
		else if ( $CurrentZoomValue == 5 )
			$CurrentZoomValue = 20;
		else if ( $CurrentZoomValue == 20 )
			$CurrentZoomValue = 30;
		else if ( $CurrentZoomValue == 30 )
			$CurrentZoomValue = 40;
		else if ( $CurrentZoomValue == 40 )
			$CurrentZoomValue = 50;
		else if ( $CurrentZoomValue == 50 )
			$CurrentZoomValue = 60;
		else if ( $CurrentZoomValue == 60 )
			$CurrentZoomValue = 70;
		else if ( $CurrentZoomValue == 70 )
			$CurrentZoomValue = 80;
		else if ( $CurrentZoomValue == 80 )
			$CurrentZoomValue = 90;
		else if ( $CurrentZoomValue == 90 )
			$CurrentZoomValue = 5;
	}
}

// zoom to user defined value...
function zoom( %val )
{
	if( $CurrentZoomValue == 0 )
		$CurrentZoomValue = 5;

	if ( %val )
	{
		$ZoomOn = true;
		setFov($CurrentZoomValue);
	}
	else
	{
		$ZoomOn = false;
		setFov($Pref::player::DefaultFov);
	}
}

function mouseZoom(%val)
{
	if($CurrentZoomValue == 0)
		$CurrentZoomValue = $Pref::Player::DefaultFov;
		
	%minFov = ServerConnection.getControlObject().getDataBlock().cameraMinFov;
	%step = ($Pref::Player::DefaultFov - %minFov)/$Pref::Player::MouseZoomSteps;

	if(%val > 0)
		$CurrentZoomValue -= %step;
	else
		$CurrentZoomValue += %step;
		
	if($CurrentZoomValue < %minFov)
		$CurrentZoomValue = %minFov;
	else if($CurrentZoomValue > $Pref::Player::DefaultFov)
		$CurrentZoomValue = $Pref::Player::DefaultFov;

	zoom(1);
}

//------------------------------------------------------------------------------
// Message HUD
//------------------------------------------------------------------------------

function toggleMessageHud(%val)
{
	if(%val)
	{
		MessageHud.isTeamMsg = false;
		MessageHud.toggleState();
	}
}

function teamMessageHud(%val)
{
	if(%val)
	{
		MessageHud.isTeamMsg = true;
		MessageHud.toggleState();
	}
}

function pageMessageHudUp( %val )
{
	if ( %val )
		pageUpMessageHud();
}

function pageMessageHudDown( %val )
{
	if ( %val )
		pageDownMessageHud();
}

function resizeMessageHud( %val )
{
	if ( %val )
		cycleMessageHudSize();
}

//------------------------------------------------------------------------------
// Misc
//------------------------------------------------------------------------------

function biggerMiniMap( %val )
{
	BigMap.visible = %val;
}

function activateCmdrScreen(%val)
{
	if(%val)
		Canvas.setContent(CmdrScreen);
}

function startRecordingDemo( %val )
{
	if ( %val )
		startDemoRecord();
}

function stopRecordingDemo( %val )
{
	if ( %val )
		stopDemoRecord();
}

//------------------------------------------------------------------------------
// Player actions
//------------------------------------------------------------------------------

function action0(%val)
{
	commandToServer('PlayerAction', 0, %val);
}


function action1(%val)
{
	commandToServer('PlayerAction', 1, %val);
}


function action2(%val)
{
	commandToServer('PlayerAction', 2, %val);
}


function action3(%val)
{
	commandToServer('PlayerAction', 3, %val);
}


function action4(%val)
{
	commandToServer('PlayerAction', 4, %val);
}


function action5(%val)
{
	commandToServer('PlayerAction', 5, %val);
}


function action6(%val)
{
	commandToServer('PlayerAction', 6, %val);
}


function action7(%val)
{
	commandToServer('PlayerAction', 7, %val);
}


function action8(%val)
{
	commandToServer('PlayerAction', 8, %val);
}


function action9(%val)
{
	commandToServer('PlayerAction', 9, %val);
}


function action10(%val)
{
	commandToServer('PlayerAction', 10, %val);
}


function action11(%val)
{
	commandToServer('PlayerAction', 11, %val);
}


function action12(%val)
{
	commandToServer('PlayerAction', 12, %val);
}


function action13(%val)
{
	commandToServer('PlayerAction', 13, %val);
}


function action14(%val)
{
	commandToServer('PlayerAction', 14, %val);
}


function action15(%val)
{
	commandToServer('PlayerAction', 15, %val);
}


function action16(%val)
{
	commandToServer('PlayerAction', 16, %val);
}


function action17(%val)
{
	commandToServer('PlayerAction', 17, %val);
}


function action18(%val)
{
	commandToServer('PlayerAction', 18, %val);
}


function action19(%val)
{
	commandToServer('PlayerAction', 19, %val);
}


function action20(%val)
{
	commandToServer('PlayerAction', 20, %val);
}


function action21(%val)
{
	commandToServer('PlayerAction', 21, %val);
}


function action22(%val)
{
	commandToServer('PlayerAction', 22, %val);
}


function action23(%val)
{
	commandToServer('PlayerAction', 23, %val);
}


function action24(%val)
{
	commandToServer('PlayerAction', 24, %val);
}


function action25(%val)
{
	commandToServer('PlayerAction', 25, %val);
}


function action26(%val)
{
	commandToServer('PlayerAction', 26, %val);
}


function action27(%val)
{
	commandToServer('PlayerAction', 27, %val);
}


function action28(%val)
{
	commandToServer('PlayerAction', 28, %val);
}


function action29(%val)
{
	commandToServer('PlayerAction', 29, %val);
}


function action30(%val)
{
	commandToServer('PlayerAction', 30, %val);
}


function action31(%val)
{
	commandToServer('PlayerAction', 31, %val);
}


function action32(%val)
{
	commandToServer('PlayerAction', 32, %val);
}


function action33(%val)
{
	commandToServer('PlayerAction', 33, %val);
}


function action34(%val)
{
	commandToServer('PlayerAction', 34, %val);
}


function action35(%val)
{
	commandToServer('PlayerAction', 35, %val);
}


function action36(%val)
{
	commandToServer('PlayerAction', 36, %val);
}


function action37(%val)
{
	commandToServer('PlayerAction', 37, %val);
}


function action38(%val)
{
	commandToServer('PlayerAction', 38, %val);
}


function action39(%val)
{
	commandToServer('PlayerAction', 39, %val);
}


