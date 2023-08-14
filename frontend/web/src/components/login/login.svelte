<script lang="ts">
	import { api } from '../../api/api';
	import { onMount } from 'svelte';
	import type { User } from '../../api/client';
	import Field from './field.svelte';
	import { createForm } from 'svelte-forms-lib';
	import * as yup from 'yup';
	import Icon from '../icon/icon.svelte';
	import { goto } from '$app/navigation';

	const { form, errors, state, handleChange, handleSubmit } = createForm({
		initialValues: {
			email: '',
			password: ''
		},
		validationSchema: yup.object().shape({
			email: yup.string().required(),
			password: yup.string().required()
		}),
		onSubmit: async (values) => {
			var res = await api.user.login({ email: values.email, password: values.password });
			if (res.data == true) goto('/');
		}
	});
</script>

<div class="border h-full flex justify-center">
	<form
		class="m-24 w-9/12 space-y-4 card p-8 flex flex-col justify-center"
		on:submit={handleSubmit}
	>
		<div class="w-full flex flex-col justify-center">
			<Icon />
			<h1 class="self-center font-bold text-3xl">Login to your account</h1>
		</div>
		<Field name="email" value={$form.email} error={$errors.email} {handleChange} />
		<Field name="password" value={$form.password} error={$errors.password} {handleChange} />
		<span>Forgot password?</span>
		<div class="flex flex-row justify-center space-x-4">
			<button class="btn variant-filled" type="submit">Cancel</button>
			<button class="btn variant-filled-primary" type="submit">Login</button>
		</div>
		<a
			href="/register"
			class="self-center hover:text-primary-500 transform transition cursor-pointer"
		>
			Don't have an account? Click here!
		</a>
	</form>
</div>
