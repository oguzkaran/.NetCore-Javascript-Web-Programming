function subscribe(action, errorAction)
{
    try {
        return action()
    }
    catch (ex) {
        errorAction(ex)
    }
}

function subscribeWithFinally(action, errorAction, finallyAction)
{
    try {
        return action()
    }
    catch (ex) {
        errorAction(ex)
    }
    finally {
        finallyAction()
    }
}

function subscribeJustFinally(action, finallyAction)
{
    try {
        return action()
    }
    finally {
        finallyAction()
    }
}


export {subscribe, subscribeJustFinally, subscribeWithFinally}
