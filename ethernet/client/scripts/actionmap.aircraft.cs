//------------------------------------------------------------------------------
// Revenge Of The Cats: Ethernet
// Copyright (C) 2008, mEthLab Interactive
//------------------------------------------------------------------------------

//------------------------------------------------------------------------------
// aircraft specific input config
//------------------------------------------------------------------------------

if( isObject( AircraftMoveMap ) )
	AircraftMoveMap.delete();
new ActionMap(AircraftMoveMap);

AircraftMoveMap.pushCallback = "aircraftMoveMapPushed";
AircraftMoveMap.popCallback = "aircraftMoveMapPopped";

function aircraftMoveMapPushed()
{
	if($pref::Input::InvertMouseWhileFlying)
		AircraftMoveMap.bind(mouse0, "yaxis", SI, $pref::Input::MouseSensitivity, pitch);
	else
		AircraftMoveMap.bind(mouse0, "yaxis", S, $pref::Input::MouseSensitivity, pitch);
}

function aircraftMoveMapPopped()
{

}
