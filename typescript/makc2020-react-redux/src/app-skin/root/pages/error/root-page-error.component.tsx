import { FC } from 'react';
import { AppRootPageErrorProps } from 'src/app/root/pages/error/root-page-error-props';

export const AppSkinRootPageErrorComponent: FC<AppRootPageErrorProps> = ({
  code
}) => {
  let message = '';

  if (!!code) {
    message = `: ${code}`;
  }

  return <div>root-page-error{message}</div>;
};
