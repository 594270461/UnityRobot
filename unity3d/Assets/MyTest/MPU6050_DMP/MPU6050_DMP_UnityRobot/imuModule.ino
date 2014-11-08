//******************************************************************************
//* Includes
//******************************************************************************
#include "UnityRobot.h"
#include "imuModule.h"


//******************************************************************************
//* Constructors
//******************************************************************************

imuModule::imuModule(int id) : UnityModule(id, false)
{
	_yaw = 0;
        _pitch = 0;
        _roll = 0;
}

void imuModule::SetYawPitchRoll(float yaw, float pitch, float roll)
{
        _yaw = (short)(yaw * 100);
        _pitch = (short)(pitch * 100);
        _roll = (short)(roll * 100);
}

//******************************************************************************
//* Override Methods
//******************************************************************************
void imuModule::OnSetup()
{
}

void imuModule::OnStart()
{
}

void imuModule::OnStop()
{	
}

void imuModule::OnProcess()
{	
}

void imuModule::OnUpdate()
{
}

void imuModule::OnAction()
{
}

void imuModule::OnFlush()
{
	UnityRobot.push(_yaw);
        UnityRobot.push(_pitch);
        UnityRobot.push(_roll);
}
