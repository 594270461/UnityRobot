#ifndef imuModule_h
#define imuModule_h

#include "UnityModule.h"


class imuModule : UnityModule
{
public:
	imuModule(int id);

        void SetYawPitchRoll(float yaw, float pitch, float roll);

protected:
	void OnSetup();
	void OnStart();
	void OnStop();
	void OnProcess();
	void OnUpdate();
	void OnAction();
	void OnFlush();

private:
    short _yaw;
    short _pitch;
    short _roll;
};

#endif

