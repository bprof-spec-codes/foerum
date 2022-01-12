export const baseHeader = {
  headers: {
    Authorization: sessionStorage.getItem("token"),
  },
};
