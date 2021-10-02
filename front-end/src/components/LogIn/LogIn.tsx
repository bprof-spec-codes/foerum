import React, { FC, useState } from "react";
import { connect } from "react-redux";
import { RouteComponentProps } from "react-router-dom";
import { IRootState } from "src/store/reducers";
import { login } from "../../store/reducers/authentication";

export interface ILoginProps
  extends StateProps,
    DispatchProps,
    RouteComponentProps<{}> {}

const LogIn: FC<ILoginProps> = (props) => {
  const [userName, setUserName] = useState<string>("");
  /* create password based on username here */

  const handleSubmit = () => {
    /* u should call props.login inside here */
  };

  return (
    <div>
      <div>
        {/* this div is the left sido of the login page(figma) */}
        <div></div>

        {/* this div is the left sido of the login page(figma) */}
        <div>
          {/* u shloud create a form inside here(u can use form tag with inputs and submit button(recommended) or a simple div with inputs) */}
          <form onSubmit={handleSubmit}>
            <input
              type="text"
              value={userName}
              onChange={(e) => setUserName(e.target.value)}
            />
            <button type="submit">button</button>
          </form>
        </div>
      </div>
    </div>
  );
};

const mapStateToProps = ({ authentication }: IRootState) => ({
  isAuthenticated: authentication.isAuthenticated,
  loginError: authentication.loginError,
});

const mapDispatchToProps = { login };

type StateProps = ReturnType<typeof mapStateToProps>;
type DispatchProps = typeof mapDispatchToProps;

export default connect(mapStateToProps, mapDispatchToProps)(LogIn);
