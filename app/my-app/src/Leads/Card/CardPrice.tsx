import { makeStyles, Typography } from "@material-ui/core";
import React from "react";

interface Props {
  price: number;
}

const useStyles = makeStyles((theme) => ({
  price: {
    fontWeight: "bold",
    marginRight: theme.spacing(1),
  },
}));

const CardPrice: React.FC<Props> = ({ price }) => {
  const classes = useStyles();

  return (
    <>
      <Typography className={classes.price} variant="inherit">
        $ {price}
      </Typography>
      <Typography variant="inherit">Lead Invitation</Typography>
    </>
  );
};

export default CardPrice;
