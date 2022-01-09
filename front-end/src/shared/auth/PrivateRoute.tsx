import { Route, Redirect } from "react-router-dom";

const PrivateRoute = ({ component: Component, ...rest }: any) => {
  const renderRedirect = (props: any) => {
    const token = sessionStorage.getItem("token");
    if (token) {
      return <Component {...props} />;
    } else {
      return (
        <Redirect
          to={{
            pathname: "/",
            /*  search: props.location.search,
            state: { from: props.location }, */
          }}
        />
      );
    }
  };
  return <Route {...rest} render={renderRedirect} />;
};

export default PrivateRoute;
